using UnityEngine;
using System.Collections.Generic;

namespace RPG.Database
{
	/// <summary>
	/// 術データ.
	/// </summary>
	[System.Serializable]
	public class AbilityData
	{
		/// <summary>
		/// 名前.
		/// </summary>
		public string name;

		/// <summary>
		/// ID.
		/// </summary>
		public int id;
		
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
		/// ターゲットを設定するプレハブ.
		/// </summary>
		public GameObject prefabSetTarget;

		/// <summary>
		/// コマンドイベントを保持しているプレハブ.
		/// </summary>
		public List<CommandEventData> commandEventDatabase;

		public int ID{ get{ return this.id; } }

		public string Name{ get{ return this.name; } }

		public string Description{ get{ return this.description; } }

		public string Shout{ get{ return this.shout; } }

		public int NeedNumber{ get{ return this.needSpirit; } }

		public Battle.TypeConstants.TargetType TargetType{ get{ return this.targetType; } }

		public GameObject PrefabSetTarget{ get{ return this.prefabSetTarget; } }

		public List<CommandEventData> CommandEventDatabase{ get{ return this.commandEventDatabase; } }
	}
}
