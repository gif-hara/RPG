using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に通常攻撃を行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandUsuallyAttack : MyMonoBehaviour, I_OnExecuteCommandHookable
	{
		[SerializeField]
		private AttackData refAttackData;

		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand( Battle.MessageConstants.ExecuteCommandHook hook )
		{
			var executer = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter;
			var selectCommandData = executer.SelectCommandData;
			var group = selectCommandData.GetTargetGroupSafe();
			var target = group.WeakCharacter;

			selectCommandData.SetTarget( target );
			selectCommandData.Impact.IsCritical = Random.Range( 0, 100 ) < 10;	Development.TODO( "会心の一撃の実装." );
			selectCommandData.Impact.Damage = CalcurateDamage.UsuallyDamage( executer, target, selectCommandData.Impact.IsCritical );
			target.TakeDamage( selectCommandData.Impact.Damage );

			this.refAttackData.Attacked();
		}
	}
}
