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
			var selectCommandData = AllPartyManager.Instance.ActiveTimeMaxBattleMember.SelectCommandData;
			var targetList = selectCommandData.GetGroupBattleMemberData( AllPartyManager.Instance, 0 );
			TODO( "通常攻撃のターゲットをHPが低いやつを狙うよう実装する." );
			Debug.Log( "targetList.Count = " + targetList.Count );
			selectCommandData.SetGiveDamage( targetList[0], 10 );
		}
	}
}
