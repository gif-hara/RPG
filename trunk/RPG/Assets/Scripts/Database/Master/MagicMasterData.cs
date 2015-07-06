using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Database
{
	/// <summary>
	/// 術マスターデータ.
	/// </summary>
	public class MagicMasterData : ScriptableObject
	{
		public List<MagicData> ElementList{ get{ return this.elementList; } }
		[SerializeField]
		private List<MagicData> elementList;

		[ContextMenu("Sort")]
		private void Sort()
		{
			this.elementList.Sort( (x, y) =>
			{
				return x.ID - y.ID;
			});
		}

		public static MagicMasterData Instance
		{
			get
			{
				return Resources.Load<MagicMasterData>( "Database/Master/Ability/Magic" );
			}
		}
	}
}
