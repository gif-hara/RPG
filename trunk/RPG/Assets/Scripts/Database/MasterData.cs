/*===========================================================================*/
/*
*     * FileName    : MasterData.cs
*
*     * Description : マスターデータ.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Database
{
	/// <summary>
	/// マスターデータ.
	/// </summary>
	public class MasterData
	{
		public MasterData()
		{
			this.Ally = AllyMasterData.Instance;
		}

		public AllyMasterData Ally{ private set; get; }
	}
}
