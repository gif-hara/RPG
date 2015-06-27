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

		/// <summary>
		/// HPが一番低いキャラクターを返す.
		/// </summary>
		/// <value>The weak member.</value>
		public BattleMemberData WeakMember
		{
			get
			{
				var result = this.List.Find( m => !m.IsDead );
				this.List.ForEach( b =>
				{
					Debug.Log( "b.IsDead = " + b.IsDead );
					if( !b.IsDead )
					{
						result = result.InstanceData.hitPoint > b.InstanceData.hitPoint ? b : result;
					}
				});

				return result;
			}
		}

		public int Count
		{
			get
			{
				return this.List.Count;
			}
		}

		public int CountAlive
		{
			get
			{
				return this.List.FindAll( b => !b.IsDead ).Count;
			}
		}

		public bool IsAllDead
		{
			get
			{
				return CountAlive <= 0;
			}
		}
	}
}
