using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

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

#if DEBUG
		public void Update()
		{
			DebugText.Instance.AppendLine( this.InstanceData.name );
			DebugText.Instance.AppendLine( "ActiveTime = " + this.ActiveTime );
		}
#endif

		public void SetModel( GameObject model )
		{
			this.Model = model;
		}
		
		/// <summary>
		/// コマンド決定処理.
		/// </summary>
		/// <param name="type">Type.</param>
		public void DecisionCommand( CommandData commandData )
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
		/// アクティブタイムの更新処理.
		/// </summary>
		/// <param name="value">Value.</param>
		public void UpdateActiveTime()
		{
			if( this.SelectCommandType == BattleTypeConstants.CommandType.None )
			{
				return;
			}

			var value =  (1.0f + (this.InstanceData.speed / 255.0f)) / 60.0f;

			this.ActiveTime += value;
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
		public BattleTypeConstants.CommandType SelectCommandType
		{
			get
			{
				if( this.SelectCommandData == null )
				{
					return BattleTypeConstants.CommandType.None;
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
	}
}
