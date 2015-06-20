/*===========================================================================*/
/*
*     * FileName    : OnActiveStateUpdateActiveTime.cs
*
*     * Description : プレイヤーのアクティブタイムを更新するコンポーネント.
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
	/// プレイヤーのアクティブタイムを更新するコンポーネント.
	/// </summary>
	public class OnActiveStateUpdateActiveTime : MyMonoBehaviour
	{
		[SerializeField]
		private BattleStateManager refStateManager;

		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		private bool isUpdate = false;

		void Update()
		{
			if( !this.isUpdate )	return;

			var party = refAllyPartyManager.Party;
			for( int i=0,imax=party.List.Count; i<imax; i++ )
			{
				var allyData = party.List[i];
				allyData.UpdateActiveTime( (1.0f + (allyData.InstanceData.speed / 255.0f)) / 60.0f );
			}

			if( party.IsAnyActiveTimeMax )
			{
				this.BroadcastMessage( BattleSceneManager.Root, BattleMessageConstants.EndUpdateActiveTimeMessage );
			}
		}

		void OnActiveState()
		{
			this.isUpdate = true;
		}

		void OnDeactiveState()
		{
			this.isUpdate = false;
		}

//		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandSelectMessage )]
//		void OnStartCommandSelect()
//		{
//			this.isUpdate = false;
//		}
//
//		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartUpdateActiveTimeMessage )]
//		void OnStartUpdateActiveTime()
//		{
//			this.isUpdate = true;
//		}
//
	}
}
