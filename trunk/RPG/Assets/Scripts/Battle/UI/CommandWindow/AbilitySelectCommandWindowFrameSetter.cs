using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 特殊能力選択ウィンドウのフレームのスケールを設定するコンポーネント.
	/// </summary>
	public class AbilitySelectCommandWindowFrameSetter : CommandWindowFrameSetter
	{
		[SerializeField]
		private int minCount;

		protected override int ElementCount
		{
			get
			{
				return minCount;
			}
		}
	}
}
