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
	/// パーティのグループ分け.
	/// </summary>
	public class Group<TBattleMemberData> where TBattleMemberData : BattleMemberData
	{
		public List<List<TBattleMemberData>> List{ private set; get; }

		public Group()
		{
			this.List = new List<List<TBattleMemberData>>();
		}

		public void Add( TBattleMemberData data )
		{
			if( this.List.Count <= 0 )
			{
				var groupElement = new List<TBattleMemberData>();
				groupElement.Add( data );
				this.List.Add( groupElement );
			}
			else
			{
				var groupElement = this.List[this.List.Count - 1];
				if( groupElement[0].CharacterData.id == data.CharacterData.id )
				{
					groupElement.Add( data );
				}
				else
				{
					groupElement = new List<TBattleMemberData>();
					groupElement.Add( data );
					this.List.Add( groupElement );
				}
			}
		}

		public TBattleMemberData GetBattleMemberData( int index )
		{
			return this.List[index][0];
		}
	}
}
