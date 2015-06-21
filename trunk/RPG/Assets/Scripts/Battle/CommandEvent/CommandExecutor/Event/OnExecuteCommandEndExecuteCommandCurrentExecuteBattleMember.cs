/*===========================================================================*/
/*
*     * FileName    : OnExecuteCommandEndExecuteCommandCurrentExecuteBattleMember.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行時にコマンド実行者の終了処理を行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandEndExecuteCommandCurrentExecuteBattleMember : MyMonoBehaviour
	{
		void OnExecuteCommand()
		{
			AllPartyManager.Instance.ActiveTimeMaxBattleMember.EndExecuteCommand();
		}
	}
}
