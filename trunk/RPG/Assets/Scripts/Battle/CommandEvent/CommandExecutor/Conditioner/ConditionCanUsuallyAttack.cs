using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 攻撃が可能であるか返すコンポーネント.
	/// </summary>
	public class ConditionCanUsuallyAttack : Common.Conditioner
	{
		[SerializeField]
		private AttackData refAttackData;

		public override bool Condition
		{
			get
			{
				return this.refAttackData.CanAttack;
			}
		}
	}
}
