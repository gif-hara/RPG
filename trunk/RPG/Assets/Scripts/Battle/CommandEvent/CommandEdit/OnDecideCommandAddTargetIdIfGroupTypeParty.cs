using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドが選択された際にGroupTypeがPartyならターゲットリストを追加するコンポーネント.
	/// </summary>
	public class OnDecideCommandAddTargetIdIfGroupTypeParty : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[Attribute.MessageMethodReceiver( MessageConstants.DecideCommandMessage )]
		void OnDecideCommand( int id )
		{
			var instanceData = BattleAllyPartyManager.Instance.Party.NoneCommandBattleMember.InstanceData;
			var ability = Database.MasterData.Instance.GetAbilityData( instanceData.abilityType, instanceData.abilityList[id] );
			if( ability.GroupType != TypeConstants.GroupType.Party )
			{
				return;
			}

			refAllyCommandSelector.CommandData.AddTargetId( this.GetPartyType( id ), 0 );
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
