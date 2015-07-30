using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時にアビリティデータから防御力の加減を行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetDefenceFromAbilityData : MyMonoBehaviour, I_OnExecuteCommandHookable, I_SetCommandEventParameter
	{
		private Database.CommandEventData data;

		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand( Battle.MessageConstants.ExecuteCommandHook hook )
		{
			var executer = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter;
			var selectCommandData = executer.SelectCommandData;
			var target = selectCommandData.Impact.Target;
			var value = target.AddDefencePercentage( CalcurateDamage.Range( this.data.PowerMin, this.data.PowerMax ) );
			selectCommandData.Impact.Defence = value;
		}

		public void SetCommandEventParameter( Database.CommandEventData data )
		{
			this.data = data;
		}
	}
}
