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

		public TypeConstants.CommandType CommandType{ private set; get; }

		[Attribute.MessageMethodReceiver( Common.MessageConstants.InputDecideMessage )]
		void OnInputDecide()
		{
			if( this.refEventHolder == null )
			{
				return;
			}

			this.Execute();
		}

		[Attribute.MessageMethodReceiver( MessageConstants.EndTurnMessage )]
		void OnEndTurn()
		{
			for( int i=0, imax=this.transform.childCount; i<imax; i++ )
			{
				Destroy( this.transform.GetChild( i ).gameObject );
			}
		}

		public void StartCommand()
		{
			var hook = CreateHook();
			BroadcastMessage( SceneRootBase.Root, MessageConstants.StartTurnMessage, hook );
			
			this.Execute();
		}

		public void End()
		{
			this.refEventHolder = null;
			var hook = CreateHook();
			BroadcastMessage( SceneRootBase.Root, MessageConstants.EndCommandExecuteMessage, hook );

			if( this.refEventHolder == null )
			{
				BroadcastMessage( SceneRootBase.Root, MessageConstants.EndTurnMessage );
			}
			else
			{
				this.Execute();
			}
		}

		public void SetCommandType( TypeConstants.CommandType commandType )
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
			SendMessage( this.refEventHolder, MessageConstants.ExecuteCommandMessage, hook );
		}

		private MessageConstants.ExecuteCommandHook CreateHook()
		{
			return new MessageConstants.ExecuteCommandHook( this );
		}

		private bool IsForceEnd
		{
			get
			{
				return BattleEnemyPartyManager.Instance.Party.IsAllDead;
			}
		}
	}
}
