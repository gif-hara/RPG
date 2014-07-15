/*===========================================================================*/
/*
*     * FileName    : EnemySelectCommandWindowLabelSetter.cs
*
*     * Description : 敵選択コマンドウィンドウのラベルを設定するコンポーネント.
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
	/// 敵選択コマンドウィンドウのラベルを設定するコンポーネント.
	/// </summary>
	public class EnemySelectCommandWindowLabelSetter : MyMonoBehaviour
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
			for( int i=0,imax=party.Count; i<imax; i++ )
			{
				builder.AppendLine( party[i].Data.name );
			}
			
			refLabel.text = builder.ToString();
		}
	}
}
