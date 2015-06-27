using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// 実際にコマンドを実行するコンポーネント.
	/// </summary>
	public class CommandExecuter : MyMonoBehaviour
	{
		private GameObject refEventHolder;

		public BattleTypeConstants.CommandType CommandType{ private set; get; }

		[Attribute.MessageMethodReceiver( CommonMessageConstants.InputDecideMessage )]
		void OnInputDecide()
		{
			if( this.refEventHolder == null )
			{
				return;
			}

			this.Execute();
		}

		public void StartCommand()
		{
			var hook = CreateHook();
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.StartTurnMessage, hook );
			
			this.Execute();
		}

		public void End()
		{
			this.refEventHolder = null;
			var hook = CreateHook();
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

		public void SetCommandType( BattleTypeConstants.CommandType commandType )
		{
			this.CommandType = commandType;
		}

		public void InsertEventHolder( GameObject eventHolder )
		{
			this.refEventHolder = eventHolder;
			this.refEventHolder.transform.parent = transform;
		}

		private void Execute()
		{
			var hook = CreateHook();
			SendMessage( this.refEventHolder, BattleMessageConstants.ExecuteCommandMessage, hook );
		}

		private BattleMessageConstants.ExecuteCommandHook CreateHook()
		{
			return new BattleMessageConstants.ExecuteCommandHook( this );
		}
	}
}
