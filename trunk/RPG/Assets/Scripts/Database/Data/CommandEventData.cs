using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Database
{
	/// <summary>
	/// 実行するコマンドに必要なデータ群.
	/// </summary>
	[System.Serializable]
	public class CommandEventData
	{
		public GameObject PrefabEventHolder{ get{ return this.prefabEventHolder; } }
		[SerializeField]
		private GameObject prefabEventHolder;

		public int PowerMin{ get{ return this.powerMin; } }
		[SerializeField]
		private int powerMin;

		public int PowerMax{ get{ return this.powerMax; } }
		[SerializeField]
		private int powerMax;

		public int Probability{ get{ return this.probability; } }
		[SerializeField]
		private int probability;

		public int ContinuationTurnMin{ get{ return this.continuationTurnMin; } }
		[SerializeField]
		private int continuationTurnMin;

		public int ContinuationTurnMax{ get{ return this.continuationTurnMax; } }
		[SerializeField]
		private int continuationTurnMax;
	}
}
