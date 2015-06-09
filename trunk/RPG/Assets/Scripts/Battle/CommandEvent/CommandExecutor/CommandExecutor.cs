/*===========================================================================*/
/*
*     * FileName    : CommandExecutor.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

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

		private int currentId = 0;

		void Awake()
		{
			this.Execute();
		}

		private void Execute()
		{
			this.BroadcastMessage( refEventList[this.currentId], BattleMessageConstants.ExecuteCommandMessage );
			this.currentId++;
		}
	}
}
