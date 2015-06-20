/*===========================================================================*/
/*
*     * FileName    : GiveDamageData.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// ダメージを与える際に必要なデータ.
	/// </summary>
	public class GiveDamageData
	{
		public BattleMemberData Target{ private set; get; }

		public int Damage{ private set; get; }

		public GiveDamageData( BattleMemberData target, int damage )
		{
			this.Target = target;
			this.Damage = damage;
		}
	}
}
