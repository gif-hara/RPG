using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Database
{
	/// <summary>
	/// アビリティマスターデータ.
	/// </summary>
	public class AbilityMasterData : ScriptableObject
	{
		public List<AbilityData> ElementList{ get{ return this.elementList; } }
		[SerializeField]
		private List<AbilityData> elementList;

		[ContextMenu("Sort")]
		private void Sort()
		{
			this.elementList.Sort( (x, y) =>
			{
				return x.ID - y.ID;
			});
		}

		public static AbilityMasterData Instance
		{
			get
			{
				return Resources.Load<AbilityMasterData>( "Database/Master/Ability/Ability" );
			}
		}
	}
}
