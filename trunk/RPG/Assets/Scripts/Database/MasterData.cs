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

		public I_AbilityData GetAbilityData( Battle.BattleTypeConstants.CommandType type, int id )
		{
			switch( type )
			{
			case RPG.Battle.BattleTypeConstants.CommandType.Magic:
				return this.Skill.ElementList[id];
			default:
				Debug.Assert( false, type + "は未対応の特殊能力タイプです." );
				return null;
			}
		}

		public AllyMasterData Ally{ private set; get; }

		public EnemyMasterData Enemy{ private set; get; }

		public SkillMasterData Skill{ private set; get; }
	}
}
