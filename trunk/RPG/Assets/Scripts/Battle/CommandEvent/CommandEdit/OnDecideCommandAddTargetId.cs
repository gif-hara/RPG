using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドが選択された際にターゲットリストを追加するコンポーネント.
	/// </summary>
	public class OnDecideCommandAddTargetId : MyMonoBehaviour
	{
		[SerializeField]
		private BattleTypeConstants.PartyType partyType;

		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.DecideCommandMessage )]
		void OnDecideCommand( int id )
		{
			refAllyCommandSelector.CommandData.AddTargetId( this.partyType, id );
		}
	}
}
