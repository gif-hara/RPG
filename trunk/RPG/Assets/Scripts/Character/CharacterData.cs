/*===========================================================================*/
/*
*     * FileName    : CharacterData.cs
*
*     * Description : キャラクターデータクラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections;

namespace RPG.Common
{
	[System.Serializable]
	public class CharacterData
	{
		/// <summary>
		/// ID.
		/// </summary>
		public int id;
		
		/// <summary>
		/// 名前.
		/// </summary>
		public string name;
		
		/// <summary>
		/// 段.
		/// </summary>
		public int level;

		/// <summary>
		/// 特殊能力.
		/// </summary>
		public Battle.BattleTypeConstants.AbilityType abilityType;
		
		/// <summary>
		/// 最大体力.
		/// </summary>
		public int maxHitPoint;
		
		/// <summary>
		/// 体力.
		/// </summary>
		public int hitPoint;
		
		/// <summary>
		/// 攻撃力.
		/// </summary>
		public int strength;
		
		/// <summary>
		/// 防御力.
		/// </summary>
		public int defence;
		
		/// <summary>
		/// 素早さ.
		/// </summary>
		public int speed;
		
		/// <summary>
		/// 回避率.
		/// </summary>
		public int avoid;

		/// <summary>
		/// 最大精神力.
		/// </summary>
		public int maxSpirit;

		/// <summary>
		/// 最小精神力.
		/// </summary>
		public int minSpirit;

		/// <summary>
		/// 現在の精神力.
		/// </summary>
		public int spirit;

		public CharacterData( int _id )
		{
			id = _id;
		}
		
		public void Initialize( string data )
		{
	//		Debug.Log( data );
			
			string[] split = data.Split( ',' );
			name = split[0];
			hitPoint = int.Parse( split[1] );
			strength = int.Parse( split[3] );
			defence = int.Parse( split[4] );
			speed = int.Parse( split[5] );
			avoid = int.Parse( split[6] );
			
			maxHitPoint = hitPoint;
		}

		public override string ToString ()
		{
			return string.Format (
				"[CharacterData: id={0}, name={1}, level={2}, abilityType={3}, maxHitPoint={4}, hitPoint={5} strength={6} defence={7}, speed={8}, avoid={9}, maxSpirit={10}, minSpirit={11}, spirit={12}]",
				id,
				name,
				level,
				abilityType,
				maxHitPoint,
				hitPoint,
				strength,
				defence,
				speed,
				avoid,
				maxSpirit,
				minSpirit,
				spirit
				);
		}
	}
}
/* End of file ==============================================================*/
