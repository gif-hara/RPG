using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 特殊能力選択ウィンドウのフレームのスケールを設定するコンポーネント.
	/// </summary>
	public class AbilitySelectCommandWindowFrameSetter : CommandWindowFrameSetter
	{
		[SerializeField]
		private int minCount;

		protected override int ElementCount
		{
			get
			{
				var abilityCount = BattleAllyPartyManager.Instance.Party.NoneCommandBattleMember.InstanceData.abilityList.Count / 2;
				return abilityCount < this.minCount ? this.minCount : abilityCount;
			}
		}
	}
}
