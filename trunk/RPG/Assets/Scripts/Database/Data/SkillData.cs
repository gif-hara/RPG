using UnityEngine;
using System.Collections.Generic;

namespace RPG.Database
{
	/// <summary>
	/// 術データ.
	/// </summary>
	[System.Serializable]
	public class SkillData
	{
		/// <summary>
		/// ID.
		/// </summary>
		public int id;

		/// <summary>
		/// 名前.
		/// </summary>
		public string name;

		/// <summary>
		/// 必要な精神力.
		/// </summary>
		public int needSpirit;

		/// <summary>
		/// 最小効果値.
		/// </summary>
		public int minPower;

		/// <summary>
		/// 最大効果値.
		/// </summary>
		public int maxPower;
	}
}
