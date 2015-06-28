using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// ダメージを与える際に必要なデータ.
	/// </summary>
	public class GiveDamageData
	{
		public BattleMemberData Target{ private set; get; }

		public int Damage{ private set; get; }

		public bool IsCritical{ private set; get; }

		public GiveDamageData( BattleMemberData target, int damage, bool isCritical )
		{
			this.Target = target;
			this.Damage = damage;
			this.IsCritical = isCritical;
		}
	}
}
