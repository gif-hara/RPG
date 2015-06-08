/*===========================================================================*/
/*
*     * FileName    : OnDecideMainCommandOpenWindow.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// メインコマンドが決定された際にコマンドウィンドウを開くコンポーネント.
	/// </summary>
	public class OnDecideMainCommandOpenWindow : MyMonoBehaviour
	{
		[SerializeField]
		private BattleTypeConstants.CommandSelectType type;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.DecideMainCommandMessage )]
		void OnDecideMainCommand()
		{
			this.BroadcastMessage( Common.SceneRootBase.Root, BattleMessageConstants.OpenCommandWindowMessage, this.type );
		}
	}
}
