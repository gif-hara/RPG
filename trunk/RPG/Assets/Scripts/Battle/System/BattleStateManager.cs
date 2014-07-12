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
			SelectCommand,
			UpdateActiveTime,
			ExecuteCommand,
		}

		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		private Common.StateMachine<BattleStateManager> stateMachine;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.PreInitializeSystemMessage )]
		void OnPreInitializeSystem()
		{
			this.stateMachine = new StateMachine<BattleStateManager>( this );
			this.stateMachine.Add( new BattleStateCommandSelect() );
			this.stateMachine.Add( new BattleStateUpdateActiveTime() );
			this.stateMachine.Add( new BattleStateCommandExecute() );
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartBattleMessage )]
		void OnStartBattle()
		{
			ChangeState( State.SelectCommand );
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.DecisionCommandMessage )]
		void OnDecisionCommand( BattleAllyPartyManager.AllyData allyData )
		{
			if( refAllyPartyManager.Party.IsAnyNoneCommand )
			{
				ChangeState( State.SelectCommand );
			}
			else
			{
				ChangeState( State.UpdateActiveTime );
			}
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.AllyMaxActiveTimeMessage )]
		void OnAllyMaxActiveTime( BattleAllyPartyManager.AllyData allyData )
		{
			ChangeState( State.ExecuteCommand );
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.EndCommandExecuteMessage )]
		void OnEndCommandExecute()
		{
		}

		public void ChangeState( State state )
		{
			this.stateMachine.Change( (int)state );
		}

		public State CurrentState
		{
			get
			{
				return (State)this.stateMachine.CurrentElementId;
			}
		}
	}
}
