using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// ターゲットデータ.
	/// </summary>
	public class TargetData
	{
		public TypeConstants.PartyType PartyType{ private set; get; }

		public int Id{ private set; get; }

		public TargetData( TypeConstants.PartyType partyType, int id )
		{
			this.PartyType = partyType;
			this.Id = id;
		}
	}
}
