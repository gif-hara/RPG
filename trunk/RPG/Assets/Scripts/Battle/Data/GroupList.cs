/*===========================================================================*/
/*
*     * FileName    : GroupList.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// パーティのグループ分け.
	/// </summary>
	public class GroupList
	{
		public List<Group> List{ private set; get; }

		public Group this[int index]
		{
			get
			{
				return this.List[index];
			}
		}

		public GroupList()
		{
			this.List = new List<Group>();
		}

		public void Add( BattleMemberData data )
		{
			if( this.List.Count <= 0 )
			{
				var groupElement = new Group();
				groupElement.Add( data );
				this.List.Add( groupElement );
			}
			else
			{
				var groupElement = this.List[this.List.Count - 1];
				if( groupElement[0].InstanceData.id == data.InstanceData.id )
				{
					groupElement.Add( data );
				}
				else
				{
					groupElement = new Group();
					groupElement.Add( data );
					this.List.Add( groupElement );
				}
			}
		}

		public BattleMemberData GetBattleMemberData( int index )
		{
			return this.List[index][0];
		}
	}
}