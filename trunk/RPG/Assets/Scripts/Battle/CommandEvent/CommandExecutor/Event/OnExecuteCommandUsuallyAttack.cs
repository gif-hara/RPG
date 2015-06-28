using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に通常攻撃を行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandUsuallyAttack : MyMonoBehaviour
	{
		[SerializeField]
		private AttackData refAttackData;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand()
		{
			var selectCommandData = AllPartyManager.Instance.ActiveTimeMaxBattleMember.SelectCommandData;
			var group = selectCommandData.GetGroupBattleMemberDataSafe( 0 );
			var target = group.WeakMember;

			var isCritical = false;	Development.TODO( "会心の一撃の実装." );
			var damage = CalcurateDamage.UsuallyDamage();
			selectCommandData.SetGiveDamage( target, damage, isCritical );
			target.TakeDamage( selectCommandData.GiveDamage.Damage );

			this.refAttackData.Attacked();
		}
	}
}
