using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Battle
{
	/// <summary>
	/// ターゲットのヒットポイントが最大か返す.
	/// </summary>
	public class ConditionIsMaxTargetCharacterHitPoint : Common.Conditioner
	{
		[SerializeField]
		private bool isMaxIfTrue;

		public override bool Condition
		{
			get
			{
				var targetInstanceData =
					AllPartyManager.Instance.ActiveTimeMaxBattleCharacter.SelectCommandData.GiveDamage.Target.InstanceData;
				return isMaxIfTrue == (targetInstanceData.hitPoint >= targetInstanceData.maxHitPoint);
			}
		}
	}
}
