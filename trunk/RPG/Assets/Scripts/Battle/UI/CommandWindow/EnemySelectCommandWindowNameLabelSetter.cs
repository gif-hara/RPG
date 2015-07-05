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
		
		[Attribute.MessageMethodReceiver( MessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow( TypeConstants.CommandSelectType type )
		{
			if( type != TypeConstants.CommandSelectType.Enemy )	return;

			StringBuilder builder = new StringBuilder();
			var group = refEnemyPartyManager.Party.GroupList;
			for( int i=0, imax=group.List.Count; i<imax; i++ )
			{
				builder.AppendLine( group.GetBattleMemberData( i ).MasterData.name );
			}

			refText.text = builder.ToString();
		}
	}
}
