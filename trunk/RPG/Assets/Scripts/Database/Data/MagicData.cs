using UnityEngine;
using System.Collections.Generic;

namespace RPG.Database
{
	/// <summary>
	/// 術データ.
	/// </summary>
	[System.Serializable]
	public class MagicData : I_AbilityData
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
		/// 説明.
		/// </summary>
		public string description;

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

		public int ID{ get{ return this.id; } }

		public string Name{ get{ return this.name; } }

		public string Description{ get{ return this.description; } }

		public int NeedNumber{ get{ return this.needSpirit; } }
	}
}
