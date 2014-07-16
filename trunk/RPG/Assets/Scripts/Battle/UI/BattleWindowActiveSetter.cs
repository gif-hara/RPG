/*===========================================================================*/
/*
*     * FileName    : BattleWindowActiveSetter.cs
*
*     * Description : バトルのコマンドウィンドウUIのアクティブフラグを設定するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// バトルのコマンドウィンドウUIのアクティブフラグを設定するコンポーネント.
	/// </summary>
	public class BattleWindowActiveSetter : MyMonoBehaviour
	{
		[System.Serializable]
		public class WindowData
		{
			public BattleTypeConstants.CommandSelectType Type{ get{ return type; } }
			[SerializeField]
			private BattleTypeConstants.CommandSelectType type;

			public GameObject TargetObject{ get{ return refTarget; } }
			[SerializeField]
			private GameObject refTarget;
		}

		[SerializeField]
		private List<WindowData> data;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow( BattleMessageConstants.OpenCommandWindowData parameter )
		{
			for( int i=0,imax=data.Count; i<imax; i++ )
			{
				data[i].TargetObject.SetActive( data[i].Type == parameter.SelectType );
			}
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartUpdateActiveTimeMessage )]
		void OnStartUpdateActiveTime()
		{
			AllDeactive();
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandExecuteMessage )]
		void OnStartCommandExecute()
		{
			AllDeactive();
		}

		private void AllDeactive()
		{
			for( int i=0,imax=data.Count; i<imax; i++ )
			{
				data[i].TargetObject.SetActive( false );
			}
		}
	}
}
