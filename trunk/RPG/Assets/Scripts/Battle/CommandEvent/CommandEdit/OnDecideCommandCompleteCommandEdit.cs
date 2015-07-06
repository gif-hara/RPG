using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド選択イベントの際にコマンド選択処理を完了するコンポーネント.
	/// </summary>
	public class OnDecideCommandCompleteCommandEdit : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[Attribute.MessageMethodReceiver(MessageConstants.DecideCommandMessage)]
		void OnDecideCommand()
		{
			this.refAllyCommandSelector.Complete();
		}
	}
}
