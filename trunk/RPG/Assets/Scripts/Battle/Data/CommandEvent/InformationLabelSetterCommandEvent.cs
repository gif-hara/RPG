/*===========================================================================*/
/*
*     * FileName    : InformationLabelSetterCommandEvent.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
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

		public List<CommandEventConstants.InformationParameterType> Parameter
		{
			get
			{
				return this.param;
			}
		}
		[SerializeField]
		private List<CommandEventConstants.InformationParameterType> param;

	}
}
