using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;
using RPG.Database;

namespace RPG.Battle
{
	/// <summary>
	/// 敵データ.
	/// </summary>
	public class Enemy : BattleCharacter
	{
		private int experience;

		private int gold;

		private A_EnemyAI AI;

		public Enemy( CharacterData data, int experience, int gold, A_EnemyAI AI )
			:base( data )
		{
			this.experience = experience;
			this.gold = gold;
			this.AI = AI;
		}

		public void ThinkCommand()
		{
			this.AI.Think( this );
		}

		protected override void Dead ()
		{
			Development.TODO( "戦闘不能アニメーション再生" );
			this.Model.SetActive( false );

			var resultData = ResultDataHolder.Instance.Data;
			resultData.AddAcquiredExperience( this.experience );
			resultData.AddGold( this.gold );
		}
	}
}
