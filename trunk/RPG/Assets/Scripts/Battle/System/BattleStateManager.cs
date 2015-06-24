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
			DoNothing,
		}

		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		[SerializeField]
		private List<GameObject> refStateEventHolders;

		private GameObject currentStateEventHolder;

		[RPG.Attribute.MessageMethodReceiver( BattleMessageConstants.PreInitializeSystemMessage )]
		void OnPreInitializeSystem()
		{
		}

		[RPG.Attribute.MessageMethodReceiver( BattleMessageConstants.StartBattleMessage )]
		void OnStartBattle()
		{
			this.NotifyActiveStateMessage( State.SelectCommand );
		}

		[RPG.Attribute.MessageMethodReceiver( BattleMessageConstants.CompleteCommandSelectMessage )]
		void OnCompleteCommandSelect( AllyData allyData )
		{
			if( refAllyPartyManager.Party.IsAnyNoneCommand )
			{
				this.NotifyActiveStateMessage( State.SelectCommand );
			}
			else if( refAllyPartyManager.Party.IsAnyActiveTimeMax )
			{
				this.NotifyActiveStateMessage( State.ExecuteCommand );
			}
			else
			{
				this.NotifyActiveStateMessage( State.UpdateActiveTime );
			}
		}

		[RPG.Attribute.MessageMethodReceiver( BattleMessageConstants.EndUpdateActiveTimeMessage )]
		void OnEndUpdateActiveTime()
		{
			this.NotifyActiveStateMessage( State.ExecuteCommand );
		}

		[RPG.Attribute.MessageMethodReceiver( BattleMessageConstants.EndTurnMessage )]
		void OnEndTurn()
		{
			if( BattleEnemyPartyManager.Instance.Party.IsAllDead )
			{
				this.NotifyActiveStateMessage( State.DoNothing );
			}
			else if( refAllyPartyManager.Party.IsAnyNoneCommand )
			{
				this.NotifyActiveStateMessage( State.SelectCommand );
			}
			else
			{
				this.NotifyActiveStateMessage( State.ExecuteCommand );
			}
		}

		private void NotifyActiveStateMessage( State state )
		{
			if( this.currentStateEventHolder != null )
			{
				this.BroadcastMessage( this.currentStateEventHolder, BattleMessageConstants.DeactiveStateMessage );
			}

			this.currentStateEventHolder = this.refStateEventHolders[(int)state];
			this.BroadcastMessage( this.currentStateEventHolder, BattleMessageConstants.ActiveStateMessage );
		}
	}
}
