/*===========================================================================*/
/*
*     * FileName    : BattleStateManager.cs
*
*     * Description : .
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
	/// .
	/// </summary>
	public class BattleStateManager : MyMonoBehaviour
	{
		public enum State : int
		{
			CommandSelect,
			UpdateActiveTime,
		}
		private Common.StateMachine<BattleStateManager> stateMachine;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.PreInitializeSystemMessage )]
		void OnPreInitializeSystem()
		{
			this.stateMachine = new StateMachine<BattleStateManager>( this );
			this.stateMachine.Add( new BattleStateCommandSelect() );
			this.stateMachine.Add( new BattleStateUpdateActiveTime() );
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartBattleMessage )]
		void OnStartBattle()
		{
			ChangeState( State.CommandSelect );
		}

		public void ChangeState( State state )
		{
			this.stateMachine.Change( (int)state );
		}
	}
}
