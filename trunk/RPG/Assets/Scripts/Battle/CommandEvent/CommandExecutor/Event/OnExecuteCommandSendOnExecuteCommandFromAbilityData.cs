using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時にさらにコマンド実行イベントを送信するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSendOnExecuteCommandFromAbilityData : MyMonoBehaviour, I_OnExecuteCommandHookable
	{
		[Attribute.MessageMethodReceiver( Battle.MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand (Battle.MessageConstants.ExecuteCommandHook hook)
		{
			var abilityData = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter.SelectCommandData.AbilityData;
			abilityData.PrefabCommandEventHolders.ForEach( p =>
			{
				var components = p.GetComponents( typeof( I_OnExecuteCommandHookable ) );
				for( int i=0, imax=components.Length; i<imax; i++ )
				{
					(components[i] as I_OnExecuteCommandHookable).OnExecuteCommand( hook );
				}

			});
		}
	}
}
