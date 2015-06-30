using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Database
{
	/// <summary>
	/// マスターデータ.
	/// </summary>
	public class MasterData
	{
		public static MasterData instance = null;

		public static MasterData Instance
		{
			get
			{
				instance = instance ?? new MasterData();

				return instance;
			}
		}

		private MasterData()
		{
			this.Ally = AllyMasterData.Instance;
			this.Enemy = EnemyMasterData.Instance;
			this.Skill = SkillMasterData.Instance;
		}

		public AllyMasterData Ally{ private set; get; }

		public EnemyMasterData Enemy{ private set; get; }

		public SkillMasterData Skill{ private set; get; }
	}
}
