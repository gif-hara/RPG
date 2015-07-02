using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドが決定された際にコマンドウィンドウを開くコンポーネント.
	/// </summary>
	public class OnDecideCommandOpenWindow : MyMonoBehaviour
	{
		[SerializeField]
		private TypeConstants.CommandSelectType type;

		[Attribute.MessageMethodReceiver( MessageConstants.DecideCommandMessage )]
		void OnDecideCommand()
		{
			this.BroadcastMessage( Common.SceneRootBase.Root, MessageConstants.OpenCommandWindowMessage, this.type );
		}
	}
}
