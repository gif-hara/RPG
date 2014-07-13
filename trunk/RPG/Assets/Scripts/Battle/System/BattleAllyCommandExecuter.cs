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
		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		private AllyData executeAllyData = null;

		private bool isUpdate = false;

		void Update()
		{
			if( !this.isUpdate )	return;

			if( Input.GetKeyDown( KeyCode.Space ) )
			{
				this.isUpdate = false;
				executeAllyData.ExecuteCommand();
				this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.EndCommandExecuteMessage );
			}
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandExecuteMessage )]
		void OnStartCommandExecute()
		{
			TODO( "コマンド実行処理の実装." );
			this.executeAllyData = refAllyPartyManager.Party.ActiveTimeMaxAllyData;
			this.isUpdate = true;
		}
	}
}
