using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドが決定された際に特殊能力IDを設定するコンポーネント.
	/// </summary>
	public class OnDecideCommandSetAbilityId : MonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[Attribute.MessageMethodReceiver(BattleMessageConstants.DecideCommandMessage)]
		void OnDecideCommand( int id )
		{
			var instanceData = BattleAllyPartyManager.Instance.Party.NoneCommandBattleMember.InstanceData;
			refAllyCommandSelector.CommandData.SetAbilityId( Database.MasterData.Instance.GetAbilityData( instanceData.abilityType, instanceData.abilityList[id] ).ID );
		}
	}
}