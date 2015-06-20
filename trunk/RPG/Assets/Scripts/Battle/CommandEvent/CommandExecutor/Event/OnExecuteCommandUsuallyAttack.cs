/*===========================================================================*/
/*
*     * FileName    : OnExecuteCommandUsuallyAttack.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に通常攻撃を行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandUsuallyAttack : MyMonoBehaviour
	{
		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand()
		{
			var selectCommandData = AllPartyManager.Instance.ActiveTimeMaxBattleMember.SelectCommandData;
			var targetList = selectCommandData.GetGroupBattleMemberData( 0 );
			int weakTargetId = 0; Development.TODO( "通常攻撃のターゲットをHPが低いやつを狙うよう実装する." );
			var target = targetList[weakTargetId];

			selectCommandData.SetGiveDamage( target, CalcurateDamage.UsuallyDamage() );
			target.TakeDamage( selectCommandData.GiveDamage.Damage );
		}
	}
}
