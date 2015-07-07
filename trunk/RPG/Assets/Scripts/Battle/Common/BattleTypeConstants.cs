using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// バトルで使用するタイプ定義.
	/// </summary>
	public class TypeConstants
	{
		/// <summary>
		/// コマンドタイプ.
		/// </summary>
		public enum CommandType : int
		{
			/// <summary> 戦う. </summary>
			Attack,
			
			/// <summary> 道具. </summary>
			Item,
			
			/// <summary> 守る. </summary>
			Defence,
			
			/// <summary> かばう. </summary>
			CoverUp,
			
			/// <summary> 逃げる. </summary>
			Escape,

			/// <summary> 無し. </summary>
			None,

			/// <summary> スキル無し. </summary>
			NoSkill,
			
			/// <summary> 術. </summary>
			Magic,
			
			/// <summary> すもう技. </summary>
			Sumo,
			
			/// <summary> 盗む. </summary>
			Steal,

			/// <summary> 勝利. </summary>
			Win,

			/// <summary> 敗北. </summary>
			Lose,
		}
		
		/// <summary>
		/// コマンド選択タイプ.
		/// </summary>
		public enum CommandSelectType : int
		{
			/// <summary> メインコマンド. </summary>
			Main,
			
			/// <summary> アイテム. </summary>
			Item,
			
			/// <summary> 味方. </summary>
			Ally,
			
			/// <summary> 敵. </summary>
			Enemy,

			/// <summary> 特殊能力. </summary>
			Ability,
		}

		/// <summary>
		/// 情報文字列表示の引数タイプ.
		/// </summary>
		public enum InformationParameterType : int
		{
			/// <summary> コマンド実行者の名前. </summary>
			ExecuteCharacterName,

			/// <summary> 与えるダメージ量. </summary>
			GiveDamage,

			/// <summary> ターゲットの名前. </summary>
			TargetName,

			/// <summary> 特殊能力の名前. </summary>
			AbilityName,

			/// <summary> 特殊能力の掛け声. </summary>
			AbilityShout,
		}

		public enum PartyType : int
		{
			Ally,

			Enemy,
		}

		public enum TargetType : int
		{
			Partner,

			Opponent,
		}

		public enum SetTextInformationType : int
		{
			Set,
			Append,
			NewLine,
		}

		public enum GroupType : int
		{
			Simple,
			Group,
			Party,
		}
	}
}
