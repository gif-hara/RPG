/*===========================================================================*/
/*
*     * FileName    : BattleInitializeData.cs
*
*     * Description : バトル初期時に必要なデータ群.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// バトル初期時に必要なデータ群.
	/// </summary>
	[System.Serializable]
	public class InitializeData
	{
		/// <summary>
		/// プレイヤーパーティデータ.
		/// </summary>
		/// <value>The player data.</value>
		public List<CharacterData> PlayerDataList{ get{ return this.playerDataList; } }
		[SerializeField]
		private List<CharacterData> playerDataList;

		public InitializeData( List<CharacterData> playerData )
		{
			this.playerDataList = playerData;
		}
	}
}
