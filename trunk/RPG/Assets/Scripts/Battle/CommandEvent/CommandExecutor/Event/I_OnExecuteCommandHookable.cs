using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Battle
{
	/// <summary>
	/// OnExecuteCommandイベントをフック可能な事を証明するインターフェイス.
	/// </summary>
	public interface I_OnExecuteCommandHookable
	{
		[Attribute.MessageMethodReceiver( Battle.MessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand( Battle.MessageConstants.ExecuteCommandHook hook );
	}
}
