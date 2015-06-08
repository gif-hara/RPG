/*===========================================================================*/
/*
*     * FileName    : AttackCommandData.cs
*
*     * Description : 戦うコマンドデータ.
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
	/// 戦うコマンドデータ.
	/// </summary>
	public class AttackCommandData : CommandData
	{
//		/// <summary>
//		/// 攻撃回数.
//		/// </summary>
//		private int attackNumber = 0;
//
//		public AttackCommandData()
//			:base( BattleTypeConstants.CommandType.Attack )
//		{
//
//		}
//
//		public override FactoryElement Clone ()
//		{
//			InternalInitialize();
//			return this;
//		}
//
//		#region implemented abstract members of CommandData
//
//		protected override Queue<List<CommandEventBase>> Notice (BattleMemberData executeMember, CommandEventHolder eventHolder)
//		{
//			this.attackNumber = 1;
//			var result = new Queue<List<CommandEventBase>>();
//			var infoList = new List<CommandEventBase>();
//			infoList.Add( eventHolder.Get( CommandEventConstants.EventName.Information_AllyAttack ) );
//			result.Enqueue( infoList );
//			return result;
//		}
//
//		protected override Queue<List<CommandEventBase>> Execute (BattleMemberData executeMember, CommandEventHolder eventHolder)
//		{
//			return null;
//			
//		}
//
//		protected override Queue<List<CommandEventBase>> Result (BattleMemberData executeMember, CommandEventHolder eventHolder)
//		{
//			return null;
//		}
//
//		protected override Queue<List<CommandEventBase>> End (BattleMemberData executeMember, CommandEventHolder eventHolder)
//		{
//			return null;
//		}
//
//		#endregion
//
	}
}
