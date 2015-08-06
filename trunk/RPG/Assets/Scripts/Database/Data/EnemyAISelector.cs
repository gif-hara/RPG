using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Database
{
	/// <summary>
	/// 敵AIを選択するクラス.
	/// </summary>
	[System.Serializable]
	public class EnemyAISelector
	{
		[System.Serializable]
		public class Element
		{
			public Battle.A_EnemyAI AI{ private set; get; }
			[SerializeField]
			private Battle.A_EnemyAI prefabAI;

			public int Weight{ get{ return this.weight; } }
			[SerializeField]
			private int weight;

			public void Initialize()
			{
				var instance = Object.Instantiate<GameObject>( this.prefabAI.gameObject );
//				instance.transform.parent = parent;
				this.AI = instance.GetComponent( typeof( Battle.A_EnemyAI ) ) as Battle.A_EnemyAI;
			}
		}

		[SerializeField]
		private List<Element> database;

		public void Initialize()
		{
			foreach( var data in database )
			{
				data.Initialize();
			}
		}

		public Battle.A_EnemyAI Get
		{
			get
			{
				var totalWeight = 0;
				foreach( var data in database )
				{
					totalWeight += data.Weight;
				}

				var random = Random.Range( 0, totalWeight );
				var currentWeight = 0;
				foreach( var data in database )
				{
					if( random >= currentWeight && random < (data.Weight + currentWeight) )
					{
						return data.AI;
					}

					currentWeight += data.Weight;
				}

				Debug.Assert( false, "あり得てはならない結果です. random = " + random );

				return null;
			}
		}
	}
}
