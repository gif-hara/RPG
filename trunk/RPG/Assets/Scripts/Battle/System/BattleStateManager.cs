using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;
using RPG.Battle;
using RPG.Attribute;

namespace RPG.Battle
{
	/// <summary>
	/// .
	/// </summary>
	public class BattleStateManager : MyMonoBehaviour
	{
		public enum State : int
		{
			SelectCommand = 0,
			UpdateActiveTime,
			ExecuteCommand,
			Win,
			Lose,
		}

		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		[SerializeField]
		private List<GameObject> refStateEventHolders;

		private GameObject currentStateEventHolder;

		void Update()
		{
			DebugText.Instance.AppendLine( "StateManager" );
			DebugText.Instance.AppendLine( "<color=aqua>" + this.currentStateEventHolder.name + "</color>" );
			DebugText.Instance.Line();
		}

		[RPG.Attribute.MessageMethodReceiver( MessageConstants.PreInitializeSystemMessage )]
		void OnPreInitializeSystem()
		{
		}

		[RPG.Attribute.MessageMethodReceiver( MessageConstants.StartBattleMessage )]
		void OnStartBattle()
		{
			this.NotifyActiveStateMessage( State.SelectCommand );
		}

		[RPG.Attribute.MessageMethodReceiver( MessageConstants.CompleteCommandSelectMessage )]
		void OnCompleteCommandSelect( Ally ally )
		{
			if( BattleAllyPartyManager.Instance.Party.IsAnyNoneCommand )
			{
				this.NotifyActiveStateMessage( State.SelectCommand );
			}
			else if( AllPartyManager.Instance.IsAnyActiveTimeMax )
			{
				this.NotifyActiveStateMessage( State.ExecuteCommand );
			}
			else
			{
				this.NotifyActiveStateMessage( State.UpdateActiveTime );
			}
		}

		[RPG.Attribute.MessageMethodReceiver( MessageConstants.EndUpdateActiveTimeMessage )]
		void OnEndUpdateActiveTime()
		{
			this.NotifyActiveStateMessage( State.ExecuteCommand );
		}

		[RPG.Attribute.MessageMethodReceiver( MessageConstants.EndTurnMessage )]
		void OnEndTurn()
		{
			if( BattleEnemyPartyManager.Instance.Party.IsAllDead )
			{
				this.NotifyActiveStateMessage( State.Win );
			}
			else if( BattleAllyPartyManager.Instance.Party.IsAllDead )
			{
				this.NotifyActiveStateMessage( State.Lose );
			}
			else if( BattleAllyPartyManager.Instance.Party.IsAnyNoneCommand )
			{
				this.NotifyActiveStateMessage( State.SelectCommand );
			}
			else if( AllPartyManager.Instance.IsAnyActiveTimeMax )
			{
				this.NotifyActiveStateMessage( State.ExecuteCommand );
			}
			else
			{
				this.NotifyActiveStateMessage( State.UpdateActiveTime );
			}
		}

		private void NotifyActiveStateMessage( State state )
		{
			if( this.currentStateEventHolder != null )
			{
				this.BroadcastMessage( this.currentStateEventHolder, MessageConstants.DeactiveStateMessage );
			}

			this.currentStateEventHolder = this.refStateEventHolders[(int)state];
			this.BroadcastMessage( this.currentStateEventHolder, MessageConstants.ActiveStateMessage );
		}
	}
}
