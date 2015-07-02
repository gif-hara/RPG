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
		[Multiline(3)]
		public string description;

		/// <summary>
		/// 掛け声.
		/// </summary>
		public string shout;

		/// <summary>
		/// 必要な精神力.
		/// </summary>
		public int needSpirit;

		/// <summary>
		/// 誰に対して行える術か.
		/// </summary>
		public Battle.TypeConstants.TargetType targetType;

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

		public string Shout{ get{ return this.shout; } }

		public int NeedNumber{ get{ return this.needSpirit; } }

		public Battle.TypeConstants.TargetType TargetType{ get{ return this.targetType; } }
	}
}
