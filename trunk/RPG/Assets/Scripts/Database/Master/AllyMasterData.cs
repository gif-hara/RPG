/*===========================================================================*/
/*
*     * FileName    : AllyMasterData.cs
*
*     * Description : 味方マスターデータ.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Database
{
	/// <summary>
	/// 味方マスターデータ.
	/// </summary>
	public class AllyMasterData : ScriptableObject
	{
		[System.Serializable]
		public class Element
		{
			public CharacterData characterData;
		}

		public List<Element> ElementList{ get{ return this.elementList; } }
		[SerializeField]
		private List<Element> elementList;

		public static AllyMasterData Instance
		{
			get
			{
				return Resources.Load<AllyMasterData>( "Database/Master/Ally" );
			}
		}
	}
}
