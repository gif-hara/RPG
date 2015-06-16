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
using RPG.Common;

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
	public class AllPartyManager : A_Singleton<AllPartyManager>
	{
		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		[SerializeField]
		private BattleEnemyPartyManager refEnemyPartyManager;

		public AllParty AllParty{ private set; get; }

		void Awake()
		{
			Instance = this;
		}

		void Start()
		{
			this.AllParty = new AllParty( this.refAllyPartyManager, this.refEnemyPartyManager );
		}

		public BattleMemberData ActiveTimeMaxBattleMember
		{
			get
			{
				var memberData = this.refAllyPartyManager.Party.ActiveTimeMaxBattleMember;
				if( memberData != null )
				{
					return memberData;
				}

				return this.refEnemyPartyManager.Party.ActiveTimeMaxBattleMember;
			}
		}
	}
}
