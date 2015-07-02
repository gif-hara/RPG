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
		private TypeConstants.PartyType partyType;

		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[Attribute.MessageMethodReceiver( MessageConstants.DecideCommandMessage )]
		void OnDecideCommand( int id )
		{
			refAllyCommandSelector.CommandData.AddTargetId( this.partyType, id );
		}
	}
}
