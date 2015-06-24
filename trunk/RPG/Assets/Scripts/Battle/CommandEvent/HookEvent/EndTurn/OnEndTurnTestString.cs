/*===========================================================================*/
/*
*     * FileName    : OnEndTurnTestString.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// OnEndTurnのタイミングでテストで文字列を表示するコンポーネント.
	/// </summary>
	public class OnEndTurnTestString : OnEndTurnHookable
	{
		[SerializeField]
		private string message;

		protected override void OnHook (BattleMessageConstants.ExecuteCommandHook hookData)
		{
			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.SetInformationTextMessage, message );
		}

		protected override bool CanHook
		{
			get
			{
				return true;
			}
		}
	}
}
