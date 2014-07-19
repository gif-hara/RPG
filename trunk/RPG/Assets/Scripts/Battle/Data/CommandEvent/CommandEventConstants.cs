/*===========================================================================*/
/*
*     * FileName    : CommandEventConstants.cs
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
	/// コマンドイベント定数.
	/// </summary>
	public class CommandEventConstants
	{
		public enum EventType : int
		{
			Information,
			AllyAttack,
			EnemyAttack,
			AllyDamage,
			EnemyDamage,
		}

		public enum EventName : int
		{
			Information_AllyAttack,
		}

		/// <summary>
		/// 情報文字列表示の引数タイプ.
		/// </summary>
		public enum InformationParameterType : int
		{
			/// <summary> コマンド実行者の名前. </summary>
			ExecuteMemberName,
		}
	}
}
