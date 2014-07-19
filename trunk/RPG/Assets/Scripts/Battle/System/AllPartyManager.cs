/*===========================================================================*/
/*
*     * FileName    : AllPartyManager.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	public class AllParty
	{
		public Party<AllyData> AllyParty{ private set; get; }

		public Party<EnemyData> EnemyParty{ private set; get; }

		public AllParty( BattleAllyPartyManager allyPartyManager, BattleEnemyPartyManager enemyPartyManager )
		{
			this.AllyParty = allyPartyManager.Party;
			this.EnemyParty = enemyPartyManager.Party;
		}
	}
	/// <summary>
	/// 全パーティを管理するコンポーネント.
	/// </summary>
	public class AllPartyManager : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		[SerializeField]
		private BattleEnemyPartyManager refEnemyPartyManager;

		public AllParty AllParty
		{
			get
			{
				return new AllParty( this.refAllyPartyManager, this.refEnemyPartyManager );
			}
		}
	}
}
