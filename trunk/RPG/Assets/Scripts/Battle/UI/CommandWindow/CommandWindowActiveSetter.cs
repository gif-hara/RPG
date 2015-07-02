using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// バトルのコマンドウィンドウUIのアクティブフラグを設定するコンポーネント.
	/// </summary>
	public class CommandWindowActiveSetter : MyMonoBehaviour
	{
		[System.Serializable]
		public class WindowData
		{
			public TypeConstants.CommandSelectType Type{ get{ return type; } }
			[SerializeField]
			private TypeConstants.CommandSelectType type;

			public GameObject TargetObject{ get{ return refTarget; } }
			[SerializeField]
			private GameObject refTarget;
		}

		[SerializeField]
		private List<WindowData> data;

		[Attribute.MessageMethodReceiver( MessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow( TypeConstants.CommandSelectType type )
		{
			for( int i=0,imax=data.Count; i<imax; i++ )
			{
				data[i].TargetObject.SetActive( data[i].Type == type );
			}
		}

//		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartUpdateActiveTimeMessage )]
//		void OnStartUpdateActiveTime()
//		{
//			AllDeactive();
//		}

		public void AllDeactive()
		{
			for( int i=0,imax=data.Count; i<imax; i++ )
			{
				data[i].TargetObject.SetActive( false );
			}
		}
	}
}
