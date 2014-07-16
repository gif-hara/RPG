/*===========================================================================*/
/*
*     * FileName    : EnemySelectCommandWindowNameLabelSetter.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
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
		private UILabel refLabel;
		
		[SerializeField]
		private BattleEnemyPartyManager refEnemyPartyManager;
		
		[Attribute.MessageMethodReceiver( BattleMessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow( BattleMessageConstants.OpenCommandWindowData parameter )
		{
			if( parameter.SelectType != BattleTypeConstants.CommandSelectType.Enemy )	return;

			StringBuilder builder = new StringBuilder();
			var party = refEnemyPartyManager.Party.List;
			var enemyData = party[0].Data;
			int number = 1;
			for( int i=1,imax=party.Count; i<imax; i++ )
			{
				if( enemyData.id == party[i].Data.id )
				{
					number++;
				}
				else
				{
					AppendNumber( ref builder, number );
					enemyData = party[i].Data;
					number = 1;
				}
			}

			AppendNumber( ref builder, number );
			refLabel.text = builder.ToString();
		}

		private static void AppendNumber( ref StringBuilder builder, int number )
		{
			builder.AppendLine( StringAsset.Format( "EnemyNumber", number.ToString() ) );
		}
	}
}
