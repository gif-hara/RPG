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

		private bool isUpdate = false;

		void Update()
		{
			if( !this.isUpdate )	return;

			var allParty = AllPartyManager.Instance.AllParty;

			this.UpdateActiveTime( allParty.Ally );
			this.UpdateActiveTime( allParty.Enemy );

			if( AllPartyManager.Instance.IsAnyActiveTimeMax )
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

		private void UpdateActiveTime<TBattleMember>( Party<TBattleMember> party ) where TBattleMember : Battle.BattleCharacter
		{
			for( int i=0,imax=party.List.Count; i<imax; i++ )
			{
				var character = party.List[i];
				character.UpdateActiveTime();
			}
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
