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

		/// <summary>
		/// 掛け声.
		/// </summary>
		/// <value>The shout.</value>
		string Shout{ get; }

		int NeedNumber{ get; }

		/// <summary>
		/// 誰に対して行える特殊能力か.
		/// </summary>
		/// <value>The type of the target.</value>
		Battle.TypeConstants.TargetType TargetType{ get; }
	}
}
