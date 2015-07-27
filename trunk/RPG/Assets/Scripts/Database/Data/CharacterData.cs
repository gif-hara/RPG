using UnityEngine;
using System.Collections.Generic;

namespace RPG.Database
{
	/// <summary>
	/// キャラクターデータクラス.
	/// </summary>
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
		public Battle.TypeConstants.CommandType abilityType;

		/// <summary>
		/// 使用出来る特殊能力IDリスト.
		/// </summary>
		public List<int> abilityList;
		
		/// <summary>
		/// 体力最大値.
		/// </summary>
		public int maxHitPoint;
		
		/// <summary>
		/// 体力現在値.
		/// </summary>
		public int hitPoint;

		/// <summary>
		/// 術最大値.
		/// </summary>
		public int maxMagicPoint;

		/// <summary>
		/// 術現在値.
		/// </summary>
		public int magicPoint;
		
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
		/// 所持している経験値.
		/// </summary>
		public int experience;

		/// <summary>
		/// 状態異常.
		/// </summary>
		[EnumFlags]
		public Common.TypeConstants.AbnormalStateType abnormalState = Common.TypeConstants.AbnormalStateType.Paralysis;

		public CharacterData( int _id )
		{
			id = _id;
		}

		public CharacterData( CharacterData other )
		{
			this.id = other.id;
			this.name = other.name;
			this.level = other.level;
			this.abilityType = other.abilityType;
			this.abilityList = new List<int>( other.abilityList );
			this.maxHitPoint = other.maxHitPoint;
			this.hitPoint = other.hitPoint;
			this.maxMagicPoint = other.maxMagicPoint;
			this.magicPoint = other.magicPoint;
			this.strength = other.strength;
			this.defence = other.defence;
			this.speed = other.speed;
			this.avoid = other.avoid;
		}

		public override string ToString ()
		{
			return string.Format (
				"[CharacterData: id={0}, name={1}, level={2}, abilityType={3}, maxHitPoint={4}, hitPoint={5} strength={6} defence={7}, speed={8}, avoid={9}]",
				id,
				name,
				level,
				abilityType,
				maxHitPoint,
				hitPoint,
				strength,
				defence,
				speed,
				avoid
				);
		}
	}
}
/* End of file ==============================================================*/
