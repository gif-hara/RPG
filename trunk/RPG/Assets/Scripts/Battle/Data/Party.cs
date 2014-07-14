/*===========================================================================*/
/*
*     * FileName    : AllyParty.cs
*
*     * Description : 味方パーティ.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 味方パーティ.
	/// </summary>
	public class Party<BattleMember> where BattleMember : BattleMemberData
	{
		public List<BattleMember> List{ private set; get; }
		
		public Party()
		{
			this.List = new List<BattleMember>();
		}
		
		public void Add( BattleMember data )
		{
			this.List.Add( data );
		}
		
		/// <summary>
		/// 誰かしらアクティブタイムが最大値に達しているか？.
		/// </summary>
		/// <value><c>true</c> if any active time max; otherwise, <c>false</c>.</value>
		public bool IsAnyActiveTimeMax
		{
			get
			{
				return ActiveTimeMaxBattleMember != null;
			}
		}
		
		/// <summary>
		/// アクティブタイムが最大のバトルメンバーを返す.
		/// </summary>
		/// <value>The active time max ally data.</value>
		public BattleMember ActiveTimeMaxBattleMember
		{
			get
			{
				return List.Find( a => a.IsActiveTimeMax );
			}
		}
		
		/// <summary>
		/// 誰かしらのバトルメンバーがコマンドを選択していないか返す.
		/// </summary>
		/// <value><c>true</c> if this instance is any none command; otherwise, <c>false</c>.</value>
		public bool IsAnyNoneCommand
		{
			get
			{
				return NoneCommandBattleMember != null;
			}
		}
		
		/// <summary>
		/// コマンド選択していないバトルメンバーを返す.
		/// </summary>
		/// <value>The none command ally data.</value>
		public BattleMember NoneCommandBattleMember
		{
			get
			{
				return List.Find( a => a.SelectCommandType == BattleTypeConstants.CommandType.None );
			}
		}
	}
}
