/*===========================================================================*/
/*
*     * FileName    : BattleAllyModelCreator.cs
*
*     * Description : バトル時のプレイヤーモデルを生成するコンポーネント.
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
	/// バトル時のプレイヤーモデルを生成するコンポーネント.
	/// </summary>
	public class BattleAllyModelCreator : MyMonoBehaviour
	{
		/// <summary>
		/// モデルの生成間隔.
		/// </summary>
		[SerializeField]
		private float Interval;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartBattleMessage )]
		void OnStartBattle()
		{
			var playerDataList = Battle.SharedData.initializeData.PlayerDataList;
			float originPosX = -((playerDataList.Count - 1) * (Interval / 2.0f));
			for( int i=0,imax=playerDataList.Count; i<imax; i++ )
			{
				var model = Instantiate( Define.GetPlayerModel( playerDataList[i].id ), transform  );
				model.transform.localPosition = new Vector3( originPosX + Interval * i, 0.0f, 0.0f );
			}
		}
	}
}
