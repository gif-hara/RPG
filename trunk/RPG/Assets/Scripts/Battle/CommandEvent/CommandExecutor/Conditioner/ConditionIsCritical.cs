using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// クリティカルであるか返すコンポーネント.
	/// </summary>
	public class ConditionIsCritical : Common.Conditioner
	{
		[SerializeField]
		private bool isCriticalIfTrue;

		public override bool Condition
		{
			get
			{
				return isCriticalIfTrue == AllPartyManager.Instance.ActiveTimeMaxBattleCharacter.SelectCommandData.Impact.IsCritical;
			}
		}
	}
}
