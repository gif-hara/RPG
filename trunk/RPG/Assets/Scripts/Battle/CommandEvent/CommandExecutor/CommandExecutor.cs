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
		private GameObject refEventHolder;

		void Awake()
		{
			this.Execute();
		}

		void OnInputDecide()
		{
			this.Execute();
		}

		public void SetEventHolder( GameObject eventHolder )
		{
			this.refEventHolder = eventHolder;
		}

		private void Execute()
		{
			this.BroadcastMessage( refEventHolder, BattleMessageConstants.ExecuteCommandMessage );
		}
	}
}
