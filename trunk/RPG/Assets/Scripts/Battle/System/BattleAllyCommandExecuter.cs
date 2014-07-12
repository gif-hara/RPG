/*===========================================================================*/
/*
*     * FileName    : BattleAllyCommandExecuter.cs
*
*     * Description : 味方のコマンドを実行するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// 味方のコマンドを実行するコンポーネント.
	/// </summary>
	public class BattleAllyCommandExecuter : MyMonoBehaviour
	{
		private BattleAllyPartyManager.AllyData executeAllyData = null;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.AllyMaxActiveTimeMessage )]
		void OnAllyMaxActiveTime( BattleAllyPartyManager.AllyData allyData )
		{
			this.executeAllyData = allyData;
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandExecuteMessage )]
		void OnStartCommandExecute()
		{
			TODO( "コマンド実行処理の実装." );
			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.EndCommandExecuteMessage );
		}
	}
}
