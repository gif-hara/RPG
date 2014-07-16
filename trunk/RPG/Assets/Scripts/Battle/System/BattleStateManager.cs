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
using RPG.Battle;
using RPG.Attribute;

//namespace RPG.Battle
//{
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

		private StateMachine<BattleStateManager> stateMachine;

		[RPG.Attribute.MessageMethodReceiver( BattleMessageConstants.PreInitializeSystemMessage )]
		void OnPreInitializeSystem()
		{
			this.stateMachine = new StateMachine<BattleStateManager>( this );
			this.stateMachine.Add( new BattleStateCommandSelect() );
			this.stateMachine.Add( new BattleStateUpdateActiveTime() );
			this.stateMachine.Add( new BattleStateCommandExecute() );
		}

		[RPG.Attribute.MessageMethodReceiver( BattleMessageConstants.StartBattleMessage )]
		void OnStartBattle()
		{
			ChangeState( State.SelectCommand );
		}

		[RPG.Attribute.MessageMethodReceiver( BattleMessageConstants.DecisionCommandMessage )]
		void OnDecisionCommand( AllyData allyData )
		{
			if( refAllyPartyManager.Party.IsAnyNoneCommand )
			{
				ChangeState( State.SelectCommand );
			}
			else if( refAllyPartyManager.Party.IsAnyActiveTimeMax )
			{
				ChangeState( State.ExecuteCommand, 1 );
			}
			else
			{
				ChangeState( State.UpdateActiveTime );
			}
		}

		[RPG.Attribute.MessageMethodReceiver( BattleMessageConstants.EndUpdateActiveTimeMessage )]
		void OnEndUpdateActiveTime()
		{
			ChangeState( State.ExecuteCommand );
		}

		[RPG.Attribute.MessageMethodReceiver( BattleMessageConstants.EndCommandExecuteMessage )]
		void OnEndCommandExecute()
		{
			if( refAllyPartyManager.Party.IsAnyNoneCommand )
			{
				ChangeState( State.SelectCommand );
			}
			else
			{
				ChangeState( State.ExecuteCommand );
			}
		}

		public void ChangeState( State state, int delayFrame = 0 )
		{
			if( delayFrame == 0 )
			{
				this.stateMachine.Change( (int)state );
			}
			else
			{
				StartCoroutine( ChangeStateCoroutine( state, delayFrame ) );
			}
		}

		public State CurrentState
		{
			get
			{
				return (State)this.stateMachine.CurrentElementId;
			}
		}

		private IEnumerator ChangeStateCoroutine( State state, int delayFrame )
		{
			this.stateMachine.ClearElement();

			for( int i=0; i<delayFrame; i++ )
			{
				yield return new WaitForEndOfFrame();
			}

			this.stateMachine.Change( (int)state );
		}
	}
//}
