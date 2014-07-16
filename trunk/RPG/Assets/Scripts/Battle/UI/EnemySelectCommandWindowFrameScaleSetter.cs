/*===========================================================================*/
/*
*     * FileName    : EnemySelectCommandWindowFrameScaleSetter.cs
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
	/// 敵選択ウィンドウのフレームのスケールを設定するコンポーネント.
	/// </summary>
	public class EnemySelectCommandWindowFrameScaleSetter : CommandWindowFrameSetter
	{
		[SerializeField]
		private BattleEnemyPartyManager refEnemyPartyManager;

		protected override int ElementCount
		{
			get
			{
				return refEnemyPartyManager.GroupCount;
			}
		}
	}
}
