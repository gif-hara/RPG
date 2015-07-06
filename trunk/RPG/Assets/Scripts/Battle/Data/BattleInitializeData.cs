using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;
using RPG.Database;

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
		public List<int> PlayerDataList{ get{ return this.playerDataList; } }
		[SerializeField]
		private List<int> playerDataList;

		/// <summary>
		/// 敵IDリスト.
		/// </summary>
		/// <value>The enemy data list.</value>
		public List<int> EnemyIdList{ get{ return this.enemyIdList; } }
		[SerializeField]
		private List<int> enemyIdList;
	}
}
