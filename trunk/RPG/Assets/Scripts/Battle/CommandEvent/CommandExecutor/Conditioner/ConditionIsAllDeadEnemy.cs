using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 敵側が全滅しているか返すコンポーネント.
	/// </summary>
	public class ConditionIsAllDeadEnemy : Common.Conditioner
	{
		/// <summary>
		/// 全滅ならtrueを返す.
		/// </summary>
		[SerializeField]
		private bool isAllDeadIfTrue;

		public override bool Condition
		{
			get
			{
				return isAllDeadIfTrue == BattleEnemyPartyManager.Instance.Party.IsAllDead;
			}
		}
	}
}
