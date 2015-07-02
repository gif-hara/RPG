using UnityEngine;
using System.Collections.Generic;
using RPG.Common;
using RPG.Framework;

namespace RPG.Battle
{
	/// <summary>
	/// ステートがアクティブになった際にコマンドを実行するコンポーネント.
	/// </summary>
	public class OnActiveStateStartCommand : MyMonoBehaviour
	{
		[SerializeField]
		private CommandExecuter refExecuter;

		[SerializeField]
		private TypeConstants.CommandType commandType;

		[SerializeField]
		private CommandEventMediator prefabMediator;

		[Attribute.MessageMethodReceiver( MessageConstants.ActiveStateMessage )]
		void OnActiveState()
		{
			var mediator = Instantiate( this.prefabMediator );
			mediator.SetEvent( refExecuter );
			refExecuter.SetCommandType( this.commandType );
			refExecuter.StartCommand();
		}
	}
}
