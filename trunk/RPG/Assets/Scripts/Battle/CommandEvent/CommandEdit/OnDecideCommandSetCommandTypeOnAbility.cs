using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドが決定された際にキャラクターの特殊能力コマンドタイプを設定するコンポーネント.
	/// </summary>
	public class OnDecideCommandSetCommandTypeOnAbility : MonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;
		
		[Attribute.MessageMethodReceiver(BattleMessageConstants.DecideCommandMessage)]
		void OnDecideCommand()
		{
			var ally = BattleAllyPartyManager.Instance.Party.NoneCommandBattleMember;
			refAllyCommandSelector.CommandData.SetCommandType( ally.InstanceData.abilityType );
		}
	}
}
