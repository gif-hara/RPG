using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドによって対象のステータスに影響を与えたデータ.
	/// </summary>
	public class CommandImpactData
	{
		public BattleCharacter Target{ private set; get; }

		public int Damage{ set; get; }

		public bool IsCritical{ set; get; }

		public CommandImpactData( BattleCharacter target )
		{
			this.Target = target;
			this.Damage = 0;
			this.IsCritical = false;
		}
	}
}
