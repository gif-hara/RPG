using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// ステートがアクティブになった際に敵AIがコマンドを選択するコンポーネント.
	/// </summary>
	public class OnActiveStateThinkEnemyCommand : MonoBehaviour
	{
		[Attribute.MessageMethodReceiver( MessageConstants.ActiveStateMessage )]
		void OnActiveState ()
		{
			BattleEnemyPartyManager.Instance.Party.List.ForEach( e =>
			{
				if( !e.IsDead && e.SelectCommandType == TypeConstants.CommandType.None )
				{
					e.ThinkCommand();
				}
			});
		}
	}
}
