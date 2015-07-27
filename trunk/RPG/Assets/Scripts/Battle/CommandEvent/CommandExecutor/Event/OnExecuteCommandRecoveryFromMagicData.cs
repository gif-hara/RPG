using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に術データから回復を行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandRecoveryFromMagicData : MyMonoBehaviour, I_OnExecuteCommandHookable, I_SetCommandEventParameter
	{
		private Database.CommandEventData data;

		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand( Battle.MessageConstants.ExecuteCommandHook hook )
		{
			var executer = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter;
			var selectCommandData = executer.SelectCommandData;
			var target = selectCommandData.Impact.Target;
			selectCommandData.Impact.Damage = CalcurateDamage.Range( data.PowerMinToInt, data.PowerMaxToInt );
			selectCommandData.Impact.IsCritical = Random.Range( 0, 100 ) < 1;	Development.TODO( "会心の術の実装." );
			target.Recovery( selectCommandData.Impact.Damage );
		}

		public void SetCommandEventParameter( Database.CommandEventData data )
		{
			this.data = data;
		}
	}
}
