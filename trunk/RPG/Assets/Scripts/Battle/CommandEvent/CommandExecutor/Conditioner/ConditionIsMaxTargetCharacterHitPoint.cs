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

		[SerializeField]
		private int targetId;

		public override bool Condition
		{
			get
			{
				var targetInstanceData =
					AllPartyManager.Instance.ActiveTimeMaxBattleCharacter.SelectCommandData.GetTargetBattleCharacterData( this.targetId ).InstanceData;
				return isMaxIfTrue == (targetInstanceData.hitPoint >= targetInstanceData.maxHitPoint);
			}
		}
	}
}
