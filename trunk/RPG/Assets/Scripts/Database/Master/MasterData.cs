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
			this.Ability = AbilityMasterData.Instance;
		}

		public AbilityData GetAbilityData( int id )
		{
			AbilityData result = this.Ability.ElementList.Find( m => m.ID == id );
			Debug.Assert( result != null, "id = " + id + "が存在しません. idが間違っていないかなど確認してください." );

			return result;
		}

		public AllyMasterData Ally{ private set; get; }

		public EnemyMasterData Enemy{ private set; get; }

		public AbilityMasterData Ability{ private set; get; }
	}
}
