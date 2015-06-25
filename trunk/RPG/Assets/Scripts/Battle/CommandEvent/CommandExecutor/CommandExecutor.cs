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
		
		void OnInputDecide()
		{
			this.Execute();
		}

		void OnEndTurn()
		{
			Destroy( gameObject );
		}

		public void StartCommand()
		{
			var hook = new BattleMessageConstants.ExecuteCommandHook( this );
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.StartTurnMessage, hook );
			
			this.Execute();
		}

		public void End()
		{
			this.refEventHolder = null;
			var hook = new BattleMessageConstants.ExecuteCommandHook( this );
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.EndCommandExecuteMessage, hook );

			if( this.refEventHolder == null )
			{
				BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.EndTurnMessage );
			}
			else
			{
				this.Execute();
			}
		}

		public void InsertEventHolder( GameObject eventHolder )
		{
			this.refEventHolder = eventHolder;
			this.refEventHolder.transform.parent = transform;
		}

		private void Execute()
		{
			var hook = new BattleMessageConstants.ExecuteCommandHook( this );
			SendMessage( this.refEventHolder, BattleMessageConstants.ExecuteCommandMessage, hook );
		}
	}
}
