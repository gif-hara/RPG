/*===========================================================================*/
/*
*     * FileName    : OnDecideCommandAddTargetId.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 敵コマンドが選択された際にターゲットリストを追加するコンポーネント.
	/// </summary>
	public class OnDecideCommandAddTargetId : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.DecideCommandMessage )]
		void OnDecideCommand( int id )
		{
			refAllyCommandSelector.CommandData.AddTargetId( id );
		}
	}
}
