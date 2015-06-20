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
		public CharacterData CharacterData{ private set; get; }

		public float ActiveTime{ private set; get; }

		public CommandData SelectCommandData{ private set; get; }

		public GameObject Model{ private set; get; }

		public BattleMemberData( CharacterData data )
		{
			this.CharacterData = data;
			this.ActiveTime = 0.0f;
		}

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

		public void EndExecuteCommand()
		{
			this.SelectCommandData = null;
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

		public override string ToString ()
		{
			return string.Format ("[BattleMemberData: Data={0}, ActiveTime={1}, SelectCommandData={2}, SelectCommandType={3}, IsActiveTimeMax={4}]", CharacterData, ActiveTime, SelectCommandData, SelectCommandType, IsActiveTimeMax);
		}
	}
}
