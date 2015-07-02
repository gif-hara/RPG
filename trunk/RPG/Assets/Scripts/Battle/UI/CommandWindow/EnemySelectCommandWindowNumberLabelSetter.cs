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

		[Attribute.MessageMethodReceiver( MessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow( TypeConstants.CommandSelectType type )
		{
			if( type != TypeConstants.CommandSelectType.Enemy )	return;

			StringBuilder builder = new StringBuilder();
			var groupList = BattleEnemyPartyManager.Instance.Party.GroupList;
			for( int i=0,imax=groupList.List.Count; i<imax; i++ )
			{
				builder.AppendLine( StringAsset.Format( "EnemyNumber", groupList[i].Count.ToString() ) );
			}
			refText.text = builder.ToString();
		}
	}
}
