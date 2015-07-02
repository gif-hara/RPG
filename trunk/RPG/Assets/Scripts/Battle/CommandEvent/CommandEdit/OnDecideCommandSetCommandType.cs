using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドが決定された際にコマンドタイプを設定するコンポーネント.
	/// </summary>
	public class OnDecideCommandSetCommandType : MonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[SerializeField]
		private TypeConstants.CommandType type;

		[Attribute.MessageMethodReceiver(MessageConstants.DecideCommandMessage)]
		void OnDecideCommand()
		{
			refAllyCommandSelector.CommandData.SetCommandType( this.type );
		}
	}
}