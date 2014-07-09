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

namespace RPG.Battle
{
	/// <summary>
	/// コマンドを選択するバトルステート.
	/// </summary>
	public class BattleStateCommandSelect : BattleStateElementBase
	{
		public BattleStateCommandSelect()
			:base( BattleStateManager.State.CommandSelect )
		{
			
		}
		
		public override void Enter (BattleStateManager owner)
		{

		}
		
		public override void Update (BattleStateManager owner)
		{
			throw new System.NotImplementedException ();
		}
		
		public override void Exit (BattleStateManager owner)
		{
			throw new System.NotImplementedException ();
		}
	}
}
