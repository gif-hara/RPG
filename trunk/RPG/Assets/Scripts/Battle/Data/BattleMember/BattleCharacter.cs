using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;
using RPG.Database;

namespace RPG.Battle
{
	/// <summary>
	/// バトルメンバーデータ.
	/// </summary>
	public abstract class BattleCharacter
	{
		public CharacterData MasterData{ private set; get; }

		public CharacterData InstanceData{ private set; get; }

		public float ActiveTime{ private set; get; }

		public CommandData SelectCommandData{ private set; get; }

		public GameObject Model{ private set; get; }

		private float addActiveTimeValue;

		public BattleCharacter( CharacterData data )
		{
			this.MasterData = data;
			this.InstanceData = new CharacterData( data );
			this.ActiveTime = 0.0f;
			this.addActiveTimeValue = 0.0f;
		}

		[System.Diagnostics.Conditional( "DEBUG" )]
		public void DrawDebugText()
		{
			DebugText.Instance.AppendLine( this.InstanceData.name );
			DebugText.Instance.AppendLine( "ActiveTime = " + this.ActiveTime );
			DebugText.Instance.AppendLine( "AddActiveTime = " + this.addActiveTimeValue );
			DebugText.Instance.AppendLine( "Strength = " + this.InstanceData.strength );
			DebugText.Instance.AppendLine( "Defence = " + this.InstanceData.defence );
			DebugText.Instance.AppendLine( this.ColorTagHP() + "HP " + this.InstanceData.hitPoint + "/" + this.InstanceData.maxHitPoint + "</color>" );
			DebugText.Instance.Line();
		}

		public void SetModel( GameObject model )
		{
			this.Model = model;
		}
		
		/// <summary>
		/// コマンド決定処理.
		/// </summary>
		/// <param name="type">Type.</param>
		public void DecideCommand( CommandData commandData )
		{
			this.SelectCommandData = commandData;
			this.SetAddActiveTimeValue();
		}

		/// <summary>
		/// コマンド実行の終了処理.
		/// </summary>
		public void EndExecuteCommand()
		{
			this.SelectCommandData = null;
			this.ActiveTime = 0.0f;
		}

		/// <summary>
		/// ダメージを受ける.
		/// </summary>
		/// <param name="damage">Damage.</param>
		public void TakeDamage( int damage )
		{
			if( DebugData.isInvincible )
			{
				return;
			}

			this.InstanceData.hitPoint -= damage;

			if( this.InstanceData.hitPoint <= 0 )
			{
				this.Dead();
			}
		}

		/// <summary>
		/// 回復処理.
		/// </summary>
		/// <param name="value">Value.</param>
		public void Recovery( int value )
		{
			this.InstanceData.hitPoint += value;
			this.InstanceData.hitPoint = this.InstanceData.hitPoint > this.InstanceData.maxHitPoint ? this.InstanceData.maxHitPoint : this.InstanceData.hitPoint;
		}

		/// <summary>
		/// 割合で攻撃力を加算する.
		/// </summary>
		/// <param name="percentage">Percentage.</param>
		public int AddStrengthPercentage( int percentage )
		{
			var value = Mathf.FloorToInt( this.MasterData.strength * (percentage / 100.0f) );
			value = value <= 0 ? 1 : value;
			this.InstanceData.strength += value;

			return value;
		}

		/// <summary>
		/// 割合で防御力を加算する.
		/// </summary>
		/// <returns>The defence percentage.</returns>
		/// <param name="percentage">Percentage.</param>
		public int AddDefencePercentage( int percentage )
		{
			var value = Mathf.FloorToInt( this.MasterData.defence * (percentage / 100.0f) );
			value = value <= 0 ? 1 : value;
			this.InstanceData.defence += value;
			
			return value;
		}
		
		/// <summary>
		/// アクティブタイムの更新処理.
		/// </summary>
		/// <param name="value">Value.</param>
		public void UpdateActiveTime()
		{
			if( this.IsDead )
			{
				return;
			}

			Debug.Assert( this.SelectCommandType != TypeConstants.CommandType.None, "コマンドが決定していません " + this.InstanceData.name );

			var random = this.addActiveTimeValue * 0.1f;
			this.ActiveTime += this.addActiveTimeValue + Random.Range( -random, random );
		}

		public void Rename( ref int classification )
		{
			this.InstanceData.name = this.MasterData.name + System.Convert.ToChar(System.Convert.ToInt32( 'A' ) + classification);
			classification++;
		}

		/// <summary>
		/// 死亡処理.
		/// </summary>
		protected abstract void Dead();

		/// <summary>
		/// 選択中のコマンドタイプを返す.
		/// 何も選択していない場合はNoneを返す.
		/// </summary>
		/// <value>The type of the select command.</value>
		public TypeConstants.CommandType SelectCommandType
		{
			get
			{
				if( this.SelectCommandData == null )
				{
					return TypeConstants.CommandType.None;
				}

				return this.SelectCommandData.Type;
			}
		}
		/// <summary>
		/// アクティブタイムが最大値か返す.
		/// </summary>
		/// <value><c>true</c> if this instance is active time max; otherwise, <c>false</c>.</value>
		public bool IsActiveTimeMax
		{
			get
			{
				return this.ActiveTime >= 1.0f;
			}
		}

		public bool IsDead
		{
			get
			{
				return this.InstanceData.hitPoint <= 0;
			}
		}

		private void SetAddActiveTimeValue()
		{
			var fixedSpeed = this.InstanceData.speed * 10.0f;
			this.addActiveTimeValue = (1.0f + (fixedSpeed / 255.0f)) / 60.0f;
		}

		public override string ToString ()
		{
			return string.Format ("[BattleMemberData: Data={0}, ActiveTime={1}, SelectCommandData={2}, SelectCommandType={3}, IsActiveTimeMax={4}]", InstanceData, ActiveTime, SelectCommandData, SelectCommandType, IsActiveTimeMax);
		}

#if DEBUG
		private string ColorTagHP()
		{
			return
				this.InstanceData.hitPoint <= 0
					? "<color=red>"
					: this.InstanceData.hitPoint < (this.InstanceData.maxHitPoint / 2)
					? "<color=orange>"
					: "<color=white>";
		}
#endif
	}
}
