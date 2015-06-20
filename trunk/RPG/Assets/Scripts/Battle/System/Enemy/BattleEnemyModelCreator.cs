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
		
		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartBattleMessage )]
		void OnStartBattle()
		{
			var partyList = BattleEnemyPartyManager.Instance.Party.List;
			float originPosX = ((partyList.Count - 1) * (Interval / 2.0f));
			for( int i=0,imax=partyList.Count; i<imax; i++ )
			{
				var model = Instantiate( Define.GetEnemyModel( partyList[i].CharacterData.id ), transform  );
				model.transform.localPosition = new Vector3( originPosX - Interval * i, 0.0f, 0.0f );
			}
		}
	}
}
