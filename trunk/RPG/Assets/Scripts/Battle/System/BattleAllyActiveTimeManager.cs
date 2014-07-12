/*===========================================================================*/
/*
*     * FileName    : BattleAllyActiveTimeManager.cs
*
*     * Description : プレイヤーのアクティブタイムを管理するコンポーネント.
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
	/// プレイヤーのアクティブタイムを管理するコンポーネント.
	/// </summary>
	public class BattleAllyActiveTimeManager : MyMonoBehaviour
	{
		[SerializeField]
		private BattleStateManager refStateManager;

		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		[SerializeField]
		private BattleAllyCommandSelector refCommandManager;

		private bool isUpdate = false;

		void Update()
		{
			if( !this.isUpdate )	return;

			var party = refAllyPartyManager.Party;
			for( int i=0,imax=party.List.Count; i<imax; i++ )
			{
				var allyData = party.List[i];
				allyData.UpdateActiveTime( (1.0f + allyData.Data.speed) / 60.0f );
			}

			var executableAlly = party.List.Find( a => a.IsActiveTimeMax );
			if( executableAlly != null )
			{
				this.BroadcastMessage( BattleSceneManager.Root, BattleMessageConstants.AllyMaxActiveTimeMessage, executableAlly );
			}
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandSelectMessage )]
		void OnStartCommandSelect()
		{
			this.isUpdate = false;
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartUpdateActiveTimeMessage )]
		void OnStartUpdateActiveTime()
		{
			this.isUpdate = true;
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandExecuteMessage )]
		void OnStartCommandExecute()
		{
			this.isUpdate = false;
		}
	}
}
