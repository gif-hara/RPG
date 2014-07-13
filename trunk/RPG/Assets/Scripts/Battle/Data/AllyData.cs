/*===========================================================================*/
/*
*     * FileName    : AllyData.cs
*
*     * Description : 味方データ.
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
	/// 味方データ.
	/// </summary>
	public class AllyData : BattleMemberData
	{
		public AllyData( CharacterData data )
			:base( data )
		{

		}
	}
}
