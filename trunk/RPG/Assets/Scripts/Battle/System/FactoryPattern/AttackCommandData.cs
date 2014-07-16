/*===========================================================================*/
/*
*     * FileName    : AttackCommandData.cs
*
*     * Description : 戦うコマンドデータ.
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
	/// 戦うコマンドデータ.
	/// </summary>
	public class AttackCommandData : CommandData
	{
		public AttackCommandData()
			:base( BattleTypeConstants.CommandType.Attack )
		{

		}

		public override FactoryElement Clone ()
		{
			return new AttackCommandData();
		}
	}
}
