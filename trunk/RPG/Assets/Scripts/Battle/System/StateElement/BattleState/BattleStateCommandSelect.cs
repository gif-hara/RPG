/*===========================================================================*/
/*
*     * FileName    : BattleStateCommandSelect.cs
*
*     * Description : コマンドを選択するバトルステート.
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
	/// コマンドを選択するバトルステート.
	/// </summary>
	public class BattleStateCommandSelect : BattleStateElementBase
	{
		public BattleStateCommandSelect()
			:base( BattleStateManager.State.SelectCommand )
		{
			
		}
		
		public override void Enter (BattleStateManager owner)
		{
			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.StartCommandSelectMessage );
		}
		
		public override void Update (BattleStateManager owner)
		{
		}
		
		public override void Exit (BattleStateManager owner)
		{
		}
	}
}
