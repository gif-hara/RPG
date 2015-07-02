using UnityEngine;
using System.Collections.Generic;
using RPG.Common;
using RPG.Framework;

namespace RPG.Battle
{
	/// <summary>
	/// ステートがアクティブになった際にアクティブタイムが最大値になったキャラクターの
	/// コマンドを実行するコンポーネント.
	/// </summary>
	public class OnActiveStateStartCommandActiveTimeMaxMember : MyMonoBehaviour
	{
		[SerializeField]
		private CommandExecuter refExecuter;

		[SerializeField]
		private CommandEventHolder refHolder;

		[Attribute.MessageMethodReceiver( MessageConstants.ActiveStateMessage )]
		void OnActiveState()
		{
			var executeMember = AllPartyManager.Instance.ActiveTimeMaxBattleMember;
			var data = refHolder.Get( executeMember.SelectCommandData.Type );
			var mediator = Instantiate( data.PrefabMediator );
			mediator.GetComponent<CommandEventMediator>().SetEvent( refExecuter );
			refExecuter.SetCommandType( data.CommandType );
			refExecuter.StartCommand();
		}
	}
}
