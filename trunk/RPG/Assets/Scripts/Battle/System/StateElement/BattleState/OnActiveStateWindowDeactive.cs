using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// .
	/// </summary>
	public class OnActiveStateWindowDeactive : MonoBehaviour
	{
		[SerializeField]
		private BattleWindowActiveSetter refWindowActiveSetter;

		void OnActiveState()
		{
			refWindowActiveSetter.AllDeactive();
		}
	}
}
