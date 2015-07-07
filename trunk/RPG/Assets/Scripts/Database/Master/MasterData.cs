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
			this.Magic = MagicMasterData.Instance;
		}

		public I_AbilityData GetAbilityData( Battle.TypeConstants.CommandType type, int id )
		{
			I_AbilityData result = null;
			switch( type )
			{
			case RPG.Battle.TypeConstants.CommandType.Magic:
				result = this.Magic.ElementList.Find( m => m.ID == id );
				break;
			default:
				Debug.Assert( false, type + "は未対応の特殊能力タイプです." );
				return null;
			}

			Debug.Assert( result != null, type + "の id = " + id + "が存在しません. idが間違っていないかなど確認してください." );

			return result;
		}

		public AllyMasterData Ally{ private set; get; }

		public EnemyMasterData Enemy{ private set; get; }

		public MagicMasterData Magic{ private set; get; }
	}
}
