/*===========================================================================*/
/*
*     * FileName    : BattleAllyActiveTimeManager.cs
*
*     * Description : プレイヤーのアクティブタイムを管理するコンポーネント.
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
	/// プレイヤーのアクティブタイムを管理するコンポーネント.
	/// </summary>
	public class BattleAllyActiveTimeManager : MyMonoBehaviour
	{
		private bool isUpdate = false;

		void Update()
		{
			if( !this.isUpdate )	return;

			TODO( "アクティブタイムの更新処理." );
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandSelectMessage )]
		void OnStartCommandSelect()
		{
			this.isUpdate = false;
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.DecisionCommandMessage )]
		void OnDecisionCommand()
		{
			this.isUpdate = true;
		}
	}
}
