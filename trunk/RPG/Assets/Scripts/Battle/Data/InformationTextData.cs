using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 情報ウィンドウの文字列を構築するクラス.
	/// </summary>
	public class InformationTextData : ScriptableObject
	{
		public string Key
		{
			get
			{
				return this.informationKey;
			}
		}
		[SerializeField]
		private string informationKey;

		public List<TypeConstants.InformationParameterType> Parameter
		{
			get
			{
				return this.param;
			}
		}
		[SerializeField]
		private List<TypeConstants.InformationParameterType> param;

	}
}
