/*===========================================================================*/
/*
*     * FileName    : BattleEnemyModelCreator.cs
*
*     * Description : バトル時の敵モデルを生成するコンポーネント.
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
	/// バトル時の敵モデルを生成するコンポーネント.
	/// </summary>
	public class BattleEnemyModelCreator : MyMonoBehaviour
	{
		private const float Interval = 2.0f;
		
		void OnPreInitializeSystem()
		{
			var enemyDataList = Battle.SharedData.initializeData.EnemyDataList;
			float originPosX = -((enemyDataList.Count - 1) * (Interval / 2.0f));
			for( int i=0,imax=enemyDataList.Count; i<imax; i++ )
			{
				var model = Instantiate( Define.GetEnemyModel( enemyDataList[i].id ), transform  );
				model.transform.localPosition = new Vector3( originPosX + Interval * i, 0.0f, 0.0f );
			}
		}
	}
}
