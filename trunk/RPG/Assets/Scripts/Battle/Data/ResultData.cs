using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// バトル結果データ.
	/// </summary>
	public class ResultData
	{
		public int AcquiredExperience{ private set; get; }

		public int AcquiredGold{ private set; get; }

		public ResultData()
		{
			this.AcquiredExperience = 0;
		}

		public void AddAcquiredExperience( int value )
		{
			this.AcquiredExperience += value;
		}

		public void AddGold( int value )
		{
			this.AcquiredGold += value;
		}
	}
}
