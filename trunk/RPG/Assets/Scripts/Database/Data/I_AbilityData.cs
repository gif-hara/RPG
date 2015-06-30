using UnityEngine;
using System.Collections.Generic;

namespace RPG.Database
{
	/// <summary>
	/// 特殊能力データ基底クラス.
	/// </summary>
	public interface I_AbilityData
	{
		int ID{ get; }

		string Name{ get; }

		string Description{ get; }

		int NeedNumber{ get; }
	}
}
