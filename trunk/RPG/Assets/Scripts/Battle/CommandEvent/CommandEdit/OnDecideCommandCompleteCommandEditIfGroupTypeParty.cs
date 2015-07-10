using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド選択イベントの際にGroupTypeがPartyならコマンド選択処理を完了するコンポーネント.
	/// </summary>
	public class OnDecideCommandCompleteCommandEditIfGroupTypeParty : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[Attribute.MessageMethodReceiver(MessageConstants.DecideCommandMessage)]
		void OnDecideCommand( int id )
		{
			var instanceData = BattleAllyPartyManager.Instance.Party.NoneCommandBattleMember.InstanceData;
			var ability = Database.MasterData.Instance.GetAbilityData( instanceData.abilityType, instanceData.abilityList[id] );
			if( ability.PrefabSetTarget.GetComponent<SubstantiationTargetParty>() == null )
			{
				return;
			}

			this.refAllyCommandSelector.Complete();
		}
	}
}
