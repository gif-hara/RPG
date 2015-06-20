/*===========================================================================*/
/*
*     * FileName    : BattleEnemyPartyManager.cs
*
*     * Description : 敵パーティ管理者コンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
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
		public Party<EnemyData> Party{ private set; get; }

		void Awake()
		{
			Instance = this;
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.PreInitializeSystemMessage )]
		void OnPreInitializeSystem()
		{
			this.Party = new Party<EnemyData>();
			
			var initializeData = SharedData.initializeData.EnemyDataList;
			for( int i=0,imax=initializeData.Count; i<imax; i++ )
			{
				this.Party.Add( new EnemyData( initializeData[i] ) );
			}
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
				var enemyData = list[0].CharacterData;
				for( int i=1,imax=list.Count; i<imax; i++ )
				{
					if( enemyData.id == list[i].CharacterData.id )
					{
						continue;
					}
					
					enemyData = list[i].CharacterData;
					result++;
				}

				return result;
			}
		}
	}
}
