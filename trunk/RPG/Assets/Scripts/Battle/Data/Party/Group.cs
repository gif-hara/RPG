using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// グループクラス.
	/// </summary>
	public class Group
	{
		public List<BattleCharacter> List{ private set; get; }

		public BattleCharacter this[int index]
		{
			get
			{
				return this.List[index];
			}
		}

		public Group()
		{
			this.List = new List<BattleCharacter>();
		}

		public void Add( BattleCharacter data )
		{
			this.List.Add( data );
		}

		public void Rename( ref int classification )
		{
			for( int i=0,imax=this.List.Count; i<imax; i++ )
			{
				this.List[i].Rename( ref classification );
			}
		}

		public BattleCharacter BattleCharacter
		{
			get
			{
				return this.List[0];
			}
		}

		/// <summary>
		/// HPが一番低いキャラクターを返す.
		/// </summary>
		/// <value>The weak member.</value>
		public BattleCharacter WeakCharacter
		{
			get
			{
				var result = this.List.Find( m => !m.IsDead );
				this.List.ForEach( b =>
				{
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
