/*===========================================================================*/
/*
*     * FileName    : AllySelectCommandWindowLabelSetter.cs
*
*     * Description : 味方選択コマンドウィンドウのラベルを設定するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RPG.Battle
{
	/// <summary>
	/// 味方選択コマンドウィンドウのラベルを設定するコンポーネント.
	/// </summary>
	public class AllySelectCommandWindowLabelSetter : MyMonoBehaviour
	{
		[SerializeField]
		private Text refText;

		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow( BattleTypeConstants.CommandSelectType type )
		{
			if( type != BattleTypeConstants.CommandSelectType.Ally )	return;

			StringBuilder builder = new StringBuilder();
			var party = refAllyPartyManager.Party.List;
			for( int i=0,imax=party.Count; i<imax; i++ )
			{
				builder.AppendLine( party[i].CharacterData.name );
			}

			refText.text = builder.ToString();
		}
	}
}
