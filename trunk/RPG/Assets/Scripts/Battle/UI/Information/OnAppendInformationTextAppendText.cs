/*===========================================================================*/
/*
*     * FileName    : OnAppendInformationTextAppendText.cs
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
	/// OnAppendInformationLabelメッセージでラベル文字列を設定するコンポーネント.
	/// </summary>
	public class OnAppendInformationTextAppendText : MyMonoBehaviour
	{
		[SerializeField]
		private Text refText;

		[Attribute.MessageMethodReceiver( MessageConstants.AppendInformationTextMessage )]
		void OnAppendInformationText( string message )
		{
			this.refText.text += message;
		}
	}
}
