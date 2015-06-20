/*===========================================================================*/
/*
*     * FileName    : Group.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// .
	/// </summary>
	public class Group
	{
		public List<BattleMemberData> List{ private set; get; }

		public BattleMemberData this[int index]
		{
			get
			{
				return this.List[index];
			}
		}

		public Group()
		{
			this.List = new List<BattleMemberData>();
		}

		public void Add( BattleMemberData data )
		{
			this.List.Add( data );
		}

		public int Count
		{
			get
			{
				return this.List.Count;
			}
		}

		public bool IsAllDead
		{
			get
			{
				return this.List.Find( b => !b.IsDead ) == null;
			}
		}
	}
}
