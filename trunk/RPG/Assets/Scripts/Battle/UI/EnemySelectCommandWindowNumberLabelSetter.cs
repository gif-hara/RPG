/*===========================================================================*/
/*
*     * FileName    : EnemySelectCommandWindowNameLabelSetter.cs
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
	/// 敵選択コマンドウィンドウの数ラベルを設定するコンポーネント.
	/// </summary>
	public class EnemySelectCommandWindowNumberLabelSetter : MyMonoBehaviour
	{
		[SerializeField]
		private Text refText;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow( BattleTypeConstants.CommandSelectType type )
		{
			if( type != BattleTypeConstants.CommandSelectType.Enemy )	return;

			StringBuilder builder = new StringBuilder();
			var group = BattleEnemyPartyManager.Instance.Party.Group;
			for( int i=0,imax=group.List.Count; i<imax; i++ )
			{
				builder.AppendLine( StringAsset.Format( "EnemyNumber", group.List[i].Count.ToString() ) );
			}
			refText.text = builder.ToString();
		}

		private static void AppendNumber( ref StringBuilder builder, int number )
		{
			builder.AppendLine( StringAsset.Format( "EnemyNumber", number.ToString() ) );
		}
	}
}
