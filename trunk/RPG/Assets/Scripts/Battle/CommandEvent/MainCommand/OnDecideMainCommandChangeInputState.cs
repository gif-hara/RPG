/*===========================================================================*/
/*
*     * FileName    : OnDecideMainCommandChangeInputState.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// メインコマンドが決定された際に入力操作ステートを切り替えるコンポーネント.
	/// </summary>
	public class OnDecideMainCommandChangeInputState : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[SerializeField]
		private BattleTypeConstants.CommandSelectType type;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.DecideMainCommandMessage )]
		void OnDecideMainCommand()
		{
			refAllyCommandSelector.ChangeInputState(type);
		}
	}
}
