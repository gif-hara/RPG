/*===========================================================================*/
/*
*     * FileName    : OnDecideCommandChangeInputState.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドが決定された際に入力操作ステートを切り替えるコンポーネント.
	/// </summary>
	public class OnDecideCommandChangeInputState : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[SerializeField]
		private BattleTypeConstants.CommandSelectType type;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.DecideCommandMessage )]
		void OnDecideCommand()
		{
			refAllyCommandSelector.ChangeInputState(type);
		}
	}
}
