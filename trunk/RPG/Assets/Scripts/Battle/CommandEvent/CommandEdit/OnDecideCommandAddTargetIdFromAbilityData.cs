using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドが選択された際に特殊能力データからターゲットリストを追加するコンポーネント.
	/// </summary>
	public class OnDecideCommandAddTargetIdFromAbilityData : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[Attribute.MessageMethodReceiver( MessageConstants.DecideCommandMessage )]
		void OnDecideCommand( int id )
		{
			refAllyCommandSelector.CommandData.AddTargetId( GetPartyType( id ), id );
		}

		private TypeConstants.PartyType GetPartyType( int id )
		{
			var instanceData = BattleAllyPartyManager.Instance.Party.NoneCommandBattleMember.InstanceData;
			var targetType = Database.MasterData.Instance.GetAbilityData( instanceData.abilityType, instanceData.abilityList[id] ).TargetType;

			return targetType == TypeConstants.TargetType.Partner
				? TypeConstants.PartyType.Ally
				: TypeConstants.PartyType.Enemy;
		}
	}
}
