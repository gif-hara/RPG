/*===========================================================================*/
/*
*     * FileName    : OnActiveStateCreateCommandExecutor.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;
using RPG.Common;
using RPG.Framework;

namespace RPG.Battle
{
	/// <summary>
	/// ステートがアクティブになった際にCommandExecutorを生成するコンポーネント.
	/// </summary>
	public class OnActiveStateCreateCommandExecutor : MyMonoBehaviour
	{
		[SerializeField]
		private CommandExecutorHolder refHolder;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ActiveStateMessage )]
		void OnActiveState()
		{
			var executeMember = BattleAllyPartyManager.Instance.Party.ActiveTimeMaxBattleMember;
			var commandExecutorPrefab = refHolder.Get( executeMember.SelectCommandData.Type );
			Instantiate( commandExecutorPrefab, transform );
		}
	}
}
