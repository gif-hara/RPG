/*===========================================================================*/
/*
*     * FileName    : CommandExecutor.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 実際にコマンドを実行するコンポーネント.
	/// </summary>
	public class CommandExecutor : MyMonoBehaviour
	{
		public BattleTypeConstants.CommandType CommandType{ get{ return this.type; } }
		[SerializeField]
		private BattleTypeConstants.CommandType type;

		[SerializeField]
		private List<GameObject> refEventList;
	}
}
