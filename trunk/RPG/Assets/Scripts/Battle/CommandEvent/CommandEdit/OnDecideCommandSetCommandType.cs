/*===========================================================================*/
/*
*     * FileName    : OnDecideCommandSetCommandType.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドが決定された際にコマンドタイプを設定するコンポーネント.
	/// </summary>
	public class OnDecideCommandSetCommandType : MonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[SerializeField]
		private BattleTypeConstants.CommandType type;

		[Attribute.MessageMethodReceiver(BattleMessageConstants.DecideCommandMessage)]
		void OnDecideCommand()
		{
			refAllyCommandSelector.CommandData.SetCommandType( this.type );
		}
	}
}