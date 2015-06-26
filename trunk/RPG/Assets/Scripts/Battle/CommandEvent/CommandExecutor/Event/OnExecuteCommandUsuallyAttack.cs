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
			var group = selectCommandData.GetGroupBattleMemberDataSafe( 0 );
			var target = group.WeakMember;

			selectCommandData.SetGiveDamage( target, CalcurateDamage.UsuallyDamage() );
			target.TakeDamage( selectCommandData.GiveDamage.Damage );
		}
	}
}
