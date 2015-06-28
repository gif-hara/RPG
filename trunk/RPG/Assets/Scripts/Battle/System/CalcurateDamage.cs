using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// ダメージ計算を行うクラス.
	/// </summary>
	public static class CalcurateDamage
	{
		/// <summary>
		/// 通常攻撃のダメージ計算.
		/// </summary>
		/// <returns>The damage.</returns>
		/// <param name="executer">Executer.</param>
		/// <param name="target">Target.</param>
		/// <param name="isCritical">If set to <c>true</c> is critical.</param>
		public static int UsuallyDamage( BattleCharacter executer, BattleCharacter target, bool isCritical )
		{
			int result = (2 * executer.InstanceData.strength - target.InstanceData.defence) / 4;
			result += Mathf.FloorToInt( ((float)result / 10.0f) * Random.Range( -1.0f, 1.0f ) );

			if( isCritical )
			{
				result *= 2;
			}

			return result;
		}

		/// <summary>
		/// 範囲ダメージ計算.
		/// </summary>
		/// <param name="min">Minimum.</param>
		/// <param name="max">Max.</param>
		public static int Range( int min, int max )
		{
			return Random.Range( min, max + 1 );
		}
	}
}
