/*===========================================================================*/
/*
*     * FileName    : BattleMemberData.cs
*
*     * Description : バトルメンバーデータ.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// バトルメンバーデータ.
	/// </summary>
	public class BattleMemberData
	{
		public CharacterData Data{ private set; get; }

		public float ActiveTime{ private set; get; }
		
		public BattleTypeConstants.CommandType SelectCommandType{ private set; get; }
		
		public BattleMemberData( CharacterData data )
		{
			this.Data = data;
			this.ActiveTime = 0.0f;
			this.SelectCommandType = BattleTypeConstants.CommandType.None;
		}
		
		/// <summary>
		/// コマンド決定処理.
		/// </summary>
		/// <param name="type">Type.</param>
		public void DecisionCommand( BattleTypeConstants.CommandType type )
		{
			this.SelectCommandType = type;
		}
		
		/// <summary>
		/// コマンド実行処理.
		/// </summary>
		public void ExecuteCommand()
		{
			this.SelectCommandType = BattleTypeConstants.CommandType.None;
			this.ActiveTime = 0.0f;
		}
		
		/// <summary>
		/// アクティブタイムの更新処理.
		/// </summary>
		/// <param name="value">Value.</param>
		public void UpdateActiveTime( float value )
		{
			this.ActiveTime += value;
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

		public override string ToString ()
		{
			return string.Format ("[BattleMemberData: Data={0}, ActiveTime={1}, SelectCommandType={2}, IsActiveTimeMax={3}]", Data, ActiveTime, SelectCommandType, IsActiveTimeMax);
		}
	}
}
