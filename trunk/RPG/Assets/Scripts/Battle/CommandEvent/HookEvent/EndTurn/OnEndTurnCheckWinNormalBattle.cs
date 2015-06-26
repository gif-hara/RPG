/*===========================================================================*/
/*
*     * FileName    : OnEndTurnCheckWinNormalBattle.cs
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
	/// OnEndTurnのタイミングで通常戦闘の勝利処理を開始するコンポーネント.
	/// </summary>
	public class OnEndTurnCheckWinNormalBattle : OnEndTurnHookable
	{
		[SerializeField]
		private string message;

		protected override void OnHook (BattleMessageConstants.ExecuteCommandHook hookData)
		{
			Development.TODO( "勝利処理の実装." );
			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.SetInformationTextMessage, message );
			this.internalIsHooked = true;
		}

		protected override bool CanHook
		{
			get
			{
				return BattleEnemyPartyManager.Instance.Party.IsAllDead;
			}
		}
	}
}
