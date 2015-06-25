/*===========================================================================*/
/*
*     * FileName    : OnActiveStateCreateCommandExecutorActiveTimeMaxMember.cs
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
	/// ステートがアクティブになった際にアクティブタイムが最大値になったキャラクターの
	/// CommandExecutorを生成するコンポーネント.
	/// </summary>
	public class OnActiveStateCreateCommandExecutorActiveTimeMaxMember : MyMonoBehaviour
	{
		[SerializeField]
		private CommandExecutorHolder refHolder;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ActiveStateMessage )]
		void OnActiveState()
		{
			var executeMember = AllPartyManager.Instance.ActiveTimeMaxBattleMember;
			var commandExecutorPrefab = refHolder.Get( executeMember.SelectCommandData.Type );
			Instantiate( commandExecutorPrefab, transform );
		}
	}
}
