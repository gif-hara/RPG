/*===========================================================================*/
/*
*     * FileName    : OnNewLineInformationTextNewLineText.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// OnNewLineInformationLabelメッセージでラベル文字列を設定するコンポーネント.
	/// </summary>
	public class OnNewLineInformationTextNewLineText : MyMonoBehaviour
	{
		[SerializeField]
		private Text refText;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.NewLineInformationTextMessage )]
		void OnNewLineInformationText( string message )
		{
			this.refText.text += System.Environment.NewLine + message;
		}
	}
}
