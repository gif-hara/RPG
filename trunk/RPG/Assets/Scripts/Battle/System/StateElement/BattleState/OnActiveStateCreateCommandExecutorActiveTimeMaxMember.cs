using UnityEngine;
using System.Collections.Generic;
using RPG.Common;
using RPG.Framework;

namespace RPG.Battle
{
	/// <summary>
	/// ステートがアクティブになった際にアクティブタイムが最大値になったキャラクターの
	/// CommandExecutorを生成するコンポーネント.
	/// </summary>
	public class OnActiveStateCreateCommandExecutorActiveTimeMaxMember : MyMonoBehaviour
	{
		[SerializeField]
		private CommandExecuter refExecuter;

		[SerializeField]
		private CommandEventHolder refHolder;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ActiveStateMessage )]
		void OnActiveState()
		{
			var executeMember = AllPartyManager.Instance.ActiveTimeMaxBattleMember;
			var commandExecutorPrefab = refHolder.Get( executeMember.SelectCommandData.Type );
			var mediator = Instantiate( commandExecutorPrefab );
			mediator.GetComponent<CommandEventMediator>().SetEvent( refExecuter );
			refExecuter.StartCommand();
		}
	}
}
