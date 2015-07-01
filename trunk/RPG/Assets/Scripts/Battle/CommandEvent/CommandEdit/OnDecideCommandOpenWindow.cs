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
		private BattleTypeConstants.CommandSelectType type;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.DecideCommandMessage )]
		void OnDecideCommand()
		{
			this.BroadcastMessage( Common.SceneRootBase.Root, BattleMessageConstants.OpenCommandWindowMessage, this.type );
		}
	}
}
