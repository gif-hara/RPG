﻿/*===========================================================================*/
/*
*     * FileName    : OnDecideCommandCompleteCommandEdit.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 敵コマンド選択イベントの際にコマンド選択処理を完了するコンポーネント.
	/// </summary>
	public class OnDecideCommandCompleteCommandEdit : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		void OnDecideCommand()
		{
			this.refAllyCommandSelector.Complete();
		}
	}
}