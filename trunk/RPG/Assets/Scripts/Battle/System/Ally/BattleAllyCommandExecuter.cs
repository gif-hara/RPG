/*===========================================================================*/
/*
*     * FileName    : BattleAllyCommandExecuter.cs
*
*     * Description : 味方のコマンドを実行するコンポーネント.
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
	/// 味方のコマンドを実行するコンポーネント.
	/// </summary>
	public class BattleAllyCommandExecuter : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		[SerializeField]
		private AllPartyManager refAllPartyManager;

		private AllyData executeAllyData = null;

		private bool isUpdate = false;

		private Queue<List<CommandEventBase>> commandEventList;

		void Update()
		{
			if( !this.isUpdate )	return;

			if( MyInput.Decide )
			{
				this.isUpdate = false;
				this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.EndCommandExecuteMessage );
			}
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandExecuteMessage )]
		void OnStartCommandExecute()
		{
			TODO( "コマンド実行処理の実装." );
			this.executeAllyData = refAllyPartyManager.Party.ActiveTimeMaxBattleMember;
			SetCommandEventList();
			ExecuteCommandEvent();
			this.isUpdate = true;
		}

		private void SetCommandEventList()
		{
//			this.commandEventList = this.executeAllyData.SelectCommandData.NextState( this.executeAllyData, this.refCommandEventHolder );
		}

		private void ExecuteCommandEvent()
		{
//			var commandEvent = this.commandEventList.Dequeue();
//			Debug.Log( commandEvent[0] );
//			var parameter = new BattleMessageConstants.NoticeCommandEventArgument(
//				commandEvent,
//				refAllPartyManager.AllParty,
//				this.executeAllyData,
//				this.executeAllyData.SelectCommandData
//				);
//			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.NoticeCommandEventMessage, parameter );
		}
	}
}
