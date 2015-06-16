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
	/// 敵選択コマンドウィンドウの名前ラベルを設定するコンポーネント.
	/// </summary>
	public class EnemySelectCommandWindowNameLabelSetter : MyMonoBehaviour
	{
		[SerializeField]
		private Text refText;
		
		[SerializeField]
		private BattleEnemyPartyManager refEnemyPartyManager;
		
		[Attribute.MessageMethodReceiver( BattleMessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow( BattleTypeConstants.CommandSelectType type )
		{
			if( type != BattleTypeConstants.CommandSelectType.Enemy )	return;

			StringBuilder builder = new StringBuilder();
			var party = refEnemyPartyManager.Party.List;
			var enemyData = party[0].Data;
			for( int i=1,imax=party.Count; i<imax; i++ )
			{
				if( enemyData.id == party[i].Data.id )
				{
					continue;
				}

				builder.AppendLine( enemyData.name );
				enemyData = party[i].Data;
			}

			builder.AppendLine( enemyData.name );
			refText.text = builder.ToString();
		}
	}
}
