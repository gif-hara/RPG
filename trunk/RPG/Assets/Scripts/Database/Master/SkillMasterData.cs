using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Database
{
	/// <summary>
	/// 術マスターデータ.
	/// </summary>
	public class SkillMasterData : ScriptableObject
	{
		public List<SkillData> ElementList{ get{ return this.elementList; } }
		[SerializeField]
		private List<SkillData> elementList;

		public static SkillMasterData Instance
		{
			get
			{
				return Resources.Load<SkillMasterData>( "Database/Master/Ability/Skill" );
			}
		}
	}
}
