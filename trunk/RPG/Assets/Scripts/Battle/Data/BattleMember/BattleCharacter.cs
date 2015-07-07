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

		public BattleCharacter( CharacterData data )
		{
			this.MasterData = data;
			this.InstanceData = new CharacterData( data );
			this.ActiveTime = 0.0f;
		}

		[System.Diagnostics.Conditional( "DEBUG" )]
		public void DrawDebugText()
		{
			DebugText.Instance.AppendLine( this.InstanceData.name );
			DebugText.Instance.AppendLine( "ActiveTime = " + this.ActiveTime );
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

			var value =  (1.0f + (this.InstanceData.speed / 255.0f)) / 60.0f;

			this.ActiveTime += value;
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
