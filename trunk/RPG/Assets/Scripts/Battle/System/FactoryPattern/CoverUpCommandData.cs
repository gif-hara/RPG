/*===========================================================================*/
/*
*     * FileName    : CoverUpCommandData.cs
*
*     * Description : かばうコマンドデータ.
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
	/// かばうコマンドデータ.
	/// </summary>
	public class CoverUpCommandData : CommandData
	{
		public CoverUpCommandData()
			:base( BattleTypeConstants.CommandType.CoverUp )
		{
			
		}
		public override FactoryElement Clone ()
		{
			InternalInitialize();
			return this;
		}

		#region implemented abstract members of CommandData

		protected override Queue<List<CommandEventBase>> Notice (BattleMemberData executeMember, CommandEventHolder eventHolder)
		{
			return null;
		}

		protected override Queue<List<CommandEventBase>> Execute (BattleMemberData executeMember, CommandEventHolder eventHolder)
		{
			return null;
		}

		protected override Queue<List<CommandEventBase>> Result (BattleMemberData executeMember, CommandEventHolder eventHolder)
		{
			return null;
		}

		protected override Queue<List<CommandEventBase>> End (BattleMemberData executeMember, CommandEventHolder eventHolder)
		{
			return null;
		}

		#endregion

	}
}
