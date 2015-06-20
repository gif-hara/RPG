/*===========================================================================*/
/*
*     * FileName    : OnExecuteCommandCalculationDamageUsuallyAttack.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に通常攻撃のダメージ計算を行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandCalculationDamageUsuallyAttack : MyMonoBehaviour
	{
		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand()
		{
			AllPartyManager.Instance.ActiveTimeMaxBattleMember.SelectCommandData.SetGiveDamage( 10 );
		}
	}
}
