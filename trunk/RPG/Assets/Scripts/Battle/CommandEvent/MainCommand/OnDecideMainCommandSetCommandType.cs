/*===========================================================================*/
/*
*     * FileName    : OnDecideMainCommandSetCommandType.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// メインコマンドが決定された際にコマンドタイプを設定するコンポーネント.
	/// </summary>
	public class OnDecideMainCommandSetCommandType : MonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[SerializeField]
		private BattleTypeConstants.CommandType type;

		[Attribute.MessageMethodReceiver(BattleMessageConstants.DecideMainCommandMessage)]
		void OnDecideMainCommand()
		{
			refAllyCommandSelector.CommandData.SetCommandType( this.type );
		}
	}
}