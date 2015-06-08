/*===========================================================================*/
/*
*     * FileName    : MainCommandWindowLabelSetter.cs
*
*     * Description : メインコマンドウィンドウのラベルを設定するコンポーネント.
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
	/// メインコマンドウィンドウのラベルを設定するコンポーネント.
	/// </summary>
	public class MainCommandWindowLabelSetter : MyMonoBehaviour
	{
		[SerializeField]
		private BattleAllyCommandSelector refAllyCommandSelector;

		[SerializeField]
		private UILabel refLabel;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow( BattleTypeConstants.CommandSelectType type )
		{
			refLabel.text = StringAsset.Format(
				"MainCommandLeftLabel",
				Common.StringAssetUtility.AbilityName( this.refAllyCommandSelector.CurrentCommandSelectAllyData.Data.abilityType )
				);
		}
	}
}
