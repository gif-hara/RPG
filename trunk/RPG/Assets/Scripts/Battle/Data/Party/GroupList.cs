using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// グループをまとめるクラス.
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

		public void Add( BattleCharacter data )
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

		public void Rename()
		{
			Dictionary<int, int> numberDictionary = new Dictionary<int, int>();
			this.List.ForEach( g =>
			{
				var id = g.BattleCharacter.MasterData.id;
				if( numberDictionary.ContainsKey( id ) )
				{
					numberDictionary[id] += g.Count;
				}
				else
				{
					numberDictionary.Add( id, g.Count );
				}
			});

			foreach( KeyValuePair<int, int> pair in numberDictionary )
			{
				if( pair.Value <= 1 )
				{
					continue;
				}

				int classification = 0;
				this.List.ForEach( g =>
				{
					if( g.BattleCharacter.MasterData.id == pair.Key )
					{
						g.Rename( ref classification );
					}
				});
			}
		}

		public BattleCharacter GetBattleMemberData( int index )
		{
			return this.List[index][0];
		}
	}
}
