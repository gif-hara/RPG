using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// 敵データ.
	/// </summary>
	public class Enemy : BattleCharacter
	{
		private int experience;

		private int gold;

		public Enemy( CharacterData data, int experience, int gold )
			:base( data )
		{
			this.experience = experience;
			this.gold = gold;
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
