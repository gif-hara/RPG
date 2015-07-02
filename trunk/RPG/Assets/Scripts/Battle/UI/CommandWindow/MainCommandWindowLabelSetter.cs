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
using UnityEngine.UI;
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
		private Text refText;

		[Attribute.MessageMethodReceiver( MessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow( TypeConstants.CommandSelectType type )
		{
			refText.text = StringAsset.Format(
				"MainCommandLeftLabel",
				Common.StringAssetUtility.AbilityName( this.refAllyCommandSelector.CurrentCommandSelectAlly.InstanceData.abilityType )
				);
		}
	}
}
