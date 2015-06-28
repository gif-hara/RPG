using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Database
{
	/// <summary>
	/// 敵マスターデータ.
	/// </summary>
	public class EnemyMasterData : ScriptableObject
	{
		[System.Serializable]
		public class Element
		{
			public CharacterData characterData;

			public int experience;

			public int gold;
		}

		public List<Element> ElementList{ get{ return this.elementList; } }
		[SerializeField]
		private List<Element> elementList;

		public static EnemyMasterData Instance
		{
			get
			{
				return Resources.Load<EnemyMasterData>( "Database/Master/Character/Enemy" );
			}
		}
	}
}
