using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 連続攻撃であるか返すコンポーネント.
	/// </summary>
	public class ConditionContinuityUsuallyAttack : Common.Conditioner
	{
		[SerializeField]
		private AttackData refAttackData;

		public override bool Condition
		{
			get
			{
				return this.refAttackData.IsContinuityAttack;
			}
		}
	}
}
