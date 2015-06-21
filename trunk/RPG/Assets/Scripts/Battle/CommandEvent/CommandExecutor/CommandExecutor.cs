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

		[SerializeField]
		private GameObject insertEventHolder;

		void Awake()
		{
			Debug.Log (gameObject.name);
			var hook = new BattleMessageConstants.ExecuteCommandHook( this );
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.StartTurnMessage, hook );

			this.Execute();
		}

		void OnInputDecide()
		{
			this.Execute();
		}

		void OnEndTurn()
		{
			Destroy( gameObject );
		}

		public void End()
		{
			this.refEventHolder = null;
			this.insertEventHolder = null;
			var hook = new BattleMessageConstants.ExecuteCommandHook( this );
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.EndCommandExecuteMessage, hook );

			if( this.CurrentEventHolder == null )
			{
				BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.EndTurnMessage );
			}
			else
			{
				this.Execute();
			}
		}

		public void SetEventHolder( GameObject eventHolder )
		{
			this.refEventHolder = eventHolder;
			this.refEventHolder.transform.parent = transform;
		}

		public void InsertEvent( GameObject insertEventHolder )
		{
			this.insertEventHolder = insertEventHolder;
			this.insertEventHolder.transform.parent = transform;
		}

		private void Execute()
		{
			var hook = new BattleMessageConstants.ExecuteCommandHook( this );
			SendMessage( this.CurrentEventHolder, BattleMessageConstants.ExecuteCommandMessage, hook );

			if( this.insertEventHolder != null )
			{
				this.insertEventHolder = null;
			}
		}

		private GameObject CurrentEventHolder
		{
			get
			{
				return this.insertEventHolder != null
					? this.insertEventHolder
					: this.refEventHolder;
			}
		}
	}
}
