/*===========================================================================*/
/*
*     * FileName    : CalcurateDamage.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// ダメージ計算を行うクラス.
	/// </summary>
	public static class CalcurateDamage
	{
		public static int UsuallyDamage( bool isCritical )
		{
			int result = 10;

			if( isCritical )
			{
				result *= 2;
			}

			return result;
		}
	}
}
