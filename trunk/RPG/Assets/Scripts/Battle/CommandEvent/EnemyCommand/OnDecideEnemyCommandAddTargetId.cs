/*===========================================================================*/
/*
*     * FileName    : OnDecideEnemyCommandAddTargetId.cs
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
	public class OnDecideEnemyCommandAddTargetId : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		void OnDecideEnemyCommand( int id )
		{
			refAllyCommandSelector.CommandData.AddTargetId( id );
		}
	}
}
