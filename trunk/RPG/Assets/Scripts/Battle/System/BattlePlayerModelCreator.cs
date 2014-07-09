/*===========================================================================*/
/*
*     * FileName    : BattlePlayerModelCreator.cs
*
*     * Description : バトル時のプレイヤーモデルを生成するコンポーネント.
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
	/// バトル時のプレイヤーモデルを生成するコンポーネント.
	/// </summary>
	public class BattlePlayerModelCreator : MyMonoBehaviour
	{
		/// <summary>
		/// モデルの生成間隔.
		/// </summary>
		[SerializeField]
		private float Interval;

		/// <summary>
		/// モデル生成後の拡張メッセージ.
		/// </summary>
		public const string CreateExtensionMessage = "OnCreateModelExtension";

		[Attribute.MessageMethodReceiver( BattleMessageConstants.PreInitializeSystemMessage )]
		void OnPreInitializeSystem()
		{
			var playerDataList = Battle.SharedData.initializeData.PlayerDataList;
			float originPosX = -((playerDataList.Count - 1) * (Interval / 2.0f));
			for( int i=0,imax=playerDataList.Count; i<imax; i++ )
			{
				var model = Instantiate( Define.GetPlayerModel( playerDataList[i].id ), transform  );
				model.transform.localPosition = new Vector3( originPosX + Interval * i, 0.0f, 0.0f );

				this.SendMessage( this, CreateExtensionMessage, model );
			}
		}
	}
}
