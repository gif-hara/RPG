using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

/// <summary>
/// ステートがアクティブになった際にStartCommandSelectMessageを流すコンポーネント.
/// </summary>
namespace RPG.Battle
{
	public class OnActiveStateBroadcastStartCommandSelect : MyMonoBehaviour
	{
		[Attribute.MessageMethodReceiver( MessageConstants.ActiveStateMessage )]
		void OnActiveState()
		{
			this.BroadcastMessage( SceneRootBase.Root, MessageConstants.StartCommandSelectMessage );
		}
	}
}
