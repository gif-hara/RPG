using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドが決定された際に特殊能力データからコマンドウィンドウを開くコンポーネント.
	/// </summary>
	public class OnDecideCommandOpenWindowFromAbilityData : MyMonoBehaviour
	{
		[Attribute.MessageMethodReceiver( MessageConstants.DecideCommandMessage )]
		void OnDecideCommand( int id )
		{
			this.BroadcastMessage( Common.SceneRootBase.Root, MessageConstants.OpenCommandWindowMessage, this.GetCommandSelectType( id ) );
		}

		private TypeConstants.CommandSelectType GetCommandSelectType( int id )
		{
			var instanceData = BattleAllyPartyManager.Instance.Party.NoneCommandBattleMember.InstanceData;
			var targetType = Database.MasterData.Instance.GetAbilityData( instanceData.abilityType, instanceData.abilityList[id] ).TargetType;
			
			return targetType == TypeConstants.TargetType.Partner
				? TypeConstants.CommandSelectType.Ally
				: TypeConstants.CommandSelectType.Enemy;
		}
	}
}
