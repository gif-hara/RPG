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

		public int PowerMinToInt{ get{ return Mathf.FloorToInt( this.powerMin ); } }
		public float PowerMin{ get{ return this.powerMin; } }
		[SerializeField]
		private float powerMin;

		public int PowerMaxToInt{ get{ return Mathf.FloorToInt( this.powerMax ); } }
		public float PowerMax{ get{ return this.powerMax; } }
		[SerializeField]
		private float powerMax;

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
