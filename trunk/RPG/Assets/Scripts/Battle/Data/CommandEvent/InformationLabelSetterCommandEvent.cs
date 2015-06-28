using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 情報ウィンドウのラベルを設定するコマンドイベント.
	/// </summary>
	public class InformationLabelSetterCommandEvent : CommandEventBase
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

		public List<BattleTypeConstants.InformationParameterType> Parameter
		{
			get
			{
				return this.param;
			}
		}
		[SerializeField]
		private List<BattleTypeConstants.InformationParameterType> param;

	}
}
