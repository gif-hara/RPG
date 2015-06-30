using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// 味方データ.
	/// </summary>
	public class Ally : BattleCharacter
	{
		public Ally( CharacterData data )
			:base( data )
		{

		}

		protected override void Dead ()
		{
			Development.TODO( "戦闘不能アニメーション再生" );
			this.Model.SetActive( false );
		}
	}
}
