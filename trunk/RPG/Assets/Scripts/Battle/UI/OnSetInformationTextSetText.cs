/*===========================================================================*/
/*
*     * FileName    : OnSetInformationTextSetText.cs
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
	/// OnSetInformationLabelメッセージでラベル文字列を設定するコンポーネント.
	/// </summary>
	public class OnSetInformationTextSetText : MyMonoBehaviour
	{
		[SerializeField]
		private Text refText;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.SetInformationTextMessage )]
		void OnSetInformationText( string message )
		{
			this.refText.text = message;
		}
	}
}
