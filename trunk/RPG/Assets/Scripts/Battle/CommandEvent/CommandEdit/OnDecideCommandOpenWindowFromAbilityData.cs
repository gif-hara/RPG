using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドが決定された際に特殊能力データからコマンドウィンドウを開くコンポーネント.
	/// </summary>
	public class OnDecideCommandOpenWindowFromAbilityData : MyMonoBehaviour
	{
		[Attribute.MessageMethodReceiver( BattleMessageConstants.DecideCommandMessage )]
		void OnDecideCommand( int id )
		{
			this.BroadcastMessage( Common.SceneRootBase.Root, BattleMessageConstants.OpenCommandWindowMessage, this.GetCommandSelectType( id ) );
		}

		private BattleTypeConstants.CommandSelectType GetCommandSelectType( int id )
		{
			var instanceData = BattleAllyPartyManager.Instance.Party.NoneCommandBattleMember.InstanceData;
			var targetType = Database.MasterData.Instance.GetAbilityData( instanceData.abilityType, instanceData.abilityList[id] ).TargetType;
			
			return targetType == BattleTypeConstants.TargetType.Partner
				? BattleTypeConstants.CommandSelectType.Ally
				: BattleTypeConstants.CommandSelectType.Enemy;
		}
	}
}
