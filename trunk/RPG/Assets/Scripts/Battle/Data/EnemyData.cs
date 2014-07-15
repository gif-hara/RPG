/*===========================================================================*/
/*
*     * FileName    : EnemyData.cs
*
*     * Description : 敵データ.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// 敵データ.
	/// </summary>
	public class EnemyData : BattleMemberData
	{
		public EnemyData( CharacterData data )
			:base( data )
		{
			
		}
	}
}
