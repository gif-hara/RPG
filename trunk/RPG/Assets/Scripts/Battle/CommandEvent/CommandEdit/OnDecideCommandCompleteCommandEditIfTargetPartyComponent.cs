using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド選択イベントの際にTargetPartyComponentが存在するならコマンド選択処理を完了するコンポーネント.
	/// </summary>
	public class OnDecideCommandCompleteCommandEditIfTargetPartyComponent : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[Attribute.MessageMethodReceiver(MessageConstants.DecideCommandMessage)]
		void OnDecideCommand( int id )
		{
			var instanceData = BattleAllyPartyManager.Instance.Party.NoneCommandBattleMember.InstanceData;
			var ability = Database.MasterData.Instance.GetAbilityData( instanceData.abilityType, instanceData.abilityList[id] );
			if( ability.PrefabCommandEventHolder.GetComponent<TargetPartyComponent>() == null )
			{
				return;
			}

			this.refAllyCommandSelector.Complete();
		}
	}
}
