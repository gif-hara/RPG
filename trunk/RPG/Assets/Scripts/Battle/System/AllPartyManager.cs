using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	public class AllParty
	{
		public Party Ally{ private set; get; }

		public Party Enemy{ private set; get; }

		public AllParty( BattleAllyPartyManager allyPartyManager, BattleEnemyPartyManager enemyPartyManager )
		{
			this.Ally = allyPartyManager.Party;
			this.Enemy = enemyPartyManager.Party;
		}

		public BattleCharacter ActiveTimeMaxBattleCharacter
		{
			get
			{
				var ally = Ally.ActiveTimeMaxBattleCharacter;
				var enemy = Enemy.ActiveTimeMaxBattleCharacter;

				if( ally != null && enemy != null )
				{
					return ally.ActiveTime > enemy.ActiveTime ? ally : enemy;
				}
				else if( ally != null && enemy == null )
				{
					return ally;
				}
				else if( ally == null && enemy != null )
				{
					return enemy;
				}

				return null;
			}
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

		public BattleCharacter ActiveTimeMaxBattleCharacter
		{
			get
			{
				return this.AllParty.ActiveTimeMaxBattleCharacter;
			}
		}

		/// <summary>
		/// 誰かしらアクティブタイムが最大値に達しているか？.
		/// </summary>
		/// <value><c>true</c> if any active time max; otherwise, <c>false</c>.</value>
		public bool IsAnyActiveTimeMax
		{
			get
			{
				return this.ActiveTimeMaxBattleCharacter != null;
			}
		}

	}
}
