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
		private BattleAllyPartyManager refAllyPartyManager;

		private bool isUpdate = false;

		void Update()
		{
			if( !this.isUpdate )	return;

			var party = refAllyPartyManager.Party;
			for( int i=0,imax=party.List.Count; i<imax; i++ )
			{
				party.List[i].UpdateActiveTime( 1.0f / 60.0f );
			}
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandSelectMessage )]
		void OnStartCommandSelect()
		{
			this.isUpdate = false;
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.DecisionCommandMessage )]
		void OnDecisionCommand()
		{
			this.isUpdate = true;
		}
	}
}
