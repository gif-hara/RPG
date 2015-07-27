using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に術データから範囲ダメージを与えるコンポーネント.
	/// </summary>
	public class OnExecuteCommandRangeAttackFromMagicData : MyMonoBehaviour, I_OnExecuteCommandHookable, I_SetCommandEventParameter
	{
		private Database.CommandEventData data;

		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand(Battle.MessageConstants.ExecuteCommandHook hook)
		{
			var executer = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter;
			var selectCommandData = executer.SelectCommandData;
			selectCommandData.Impact.Damage = CalcurateDamage.Range( this.data.PowerMin, this.data.PowerMax );
			selectCommandData.Impact.Target.TakeDamage( selectCommandData.Impact.Damage );
		}

		public void SetCommandEventParameter( Database.CommandEventData data )
		{
			this.data = data;
		}
	}
}
