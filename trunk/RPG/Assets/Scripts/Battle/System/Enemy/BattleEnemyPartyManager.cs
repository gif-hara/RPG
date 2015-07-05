using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// 敵パーティ管理者コンポーネント.
	/// </summary>
	public class BattleEnemyPartyManager : A_Singleton<BattleEnemyPartyManager>
	{
		public Party<Enemy> Party{ private set; get; }

		void Awake()
		{
			Instance = this;
		}

#if DEBUG
		void Update()
		{
			this.Party.List.ForEach( e => e.DrawDebugText() );
		}
#endif


		[Attribute.MessageMethodReceiver( MessageConstants.PreInitializeSystemMessage )]
		void OnPreInitializeSystem()
		{
			this.Party = new Party<Enemy>();
			
			var initializeData = SharedData.initializeData.EnemyIdList;

			for( int i=0,imax=initializeData.Count; i<imax; i++ )
			{
				var data = Database.MasterData.Instance.Enemy.ElementList[initializeData[i]];
				this.Party.Add( new Enemy( data.characterData, data.experience, data.gold, data.prefabAI ) );
			}

			this.Party.Rename();
		}
		/// <summary>
		/// パーティの数をグループ単位で返す.
		/// </summary>
		/// <value>The group count.</value>
		public int GroupCount
		{
			get
			{
				var list = Party.List;
				if( list.Count == 0 )	return 0;

				int result = 1;
				var enemyData = list[0].InstanceData;
				for( int i=1,imax=list.Count; i<imax; i++ )
				{
					if( enemyData.id == list[i].InstanceData.id )
					{
						continue;
					}
					
					enemyData = list[i].InstanceData;
					result++;
				}

				return result;
			}
		}
	}
}
