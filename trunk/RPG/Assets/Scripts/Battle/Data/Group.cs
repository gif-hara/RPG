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
	public class Group
	{
		public List<List<BattleMemberData>> List{ private set; get; }

		public Group()
		{
			this.List = new List<List<BattleMemberData>>();
		}

		public void Add( BattleMemberData data )
		{
			if( this.List.Count <= 0 )
			{
				var groupElement = new List<BattleMemberData>();
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
					groupElement = new List<BattleMemberData>();
					groupElement.Add( data );
					this.List.Add( groupElement );
				}
			}
		}

		public List<BattleMemberData> FindList( BattleMemberData battleMember )
		{
			for( int i=0, imax=this.List.Count; i<imax; i++ )
			{
				if( this.List[i].Find( (b) => b == battleMember ) != null )
				{
					return this.List[i];
				}
			}

			Debug.Assert( false, "List did not hit. battleMember = " + battleMember.ToString() );
			return null;
		}

		public BattleMemberData GetBattleMemberData( int index )
		{
			return this.List[index][0];
		}
	}
}
