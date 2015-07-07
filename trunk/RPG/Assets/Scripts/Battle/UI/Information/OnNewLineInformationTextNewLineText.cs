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

		[Attribute.MessageMethodReceiver( MessageConstants.NewLineInformationTextMessage )]
		void OnNewLineInformationText( string message )
		{
			if( this.refText.text == string.Empty )
			{
				this.refText.text += message;
			}
			else
			{
				this.refText.text += System.Environment.NewLine + message;
			}
		}
	}
}
