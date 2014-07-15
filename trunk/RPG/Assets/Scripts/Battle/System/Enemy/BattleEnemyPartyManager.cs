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

namespace RPG.Battle
{
	/// <summary>
	/// 敵パーティ管理者コンポーネント.
	/// </summary>
	public class BattleEnemyPartyManager : MyMonoBehaviour
	{
		public Party<EnemyData> Party{ private set; get; }

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
	}
}
