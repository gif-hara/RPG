/*===========================================================================*/
/*
*     * FileName    : CoverUpCommandData.cs
*
*     * Description : かばうコマンドデータ.
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
	/// かばうコマンドデータ.
	/// </summary>
	public class CoverUpCommandData : CommandData
	{
		public CoverUpCommandData()
			:base( BattleTypeConstants.CommandType.CoverUp )
		{
			
		}
		public override FactoryElement Clone ()
		{
			return new CoverUpCommandData();
		}
	}
}
