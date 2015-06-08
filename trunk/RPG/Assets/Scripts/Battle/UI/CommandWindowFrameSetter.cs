/*===========================================================================*/
/*
*     * FileName    : CommandWindowFrameSetter.cs
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
	/// コマンド選択ウィンドウのフレームのスケール値を設定するコンポーネント.
	/// </summary>
	public abstract class CommandWindowFrameSetter : MyMonoBehaviour
	{
		[SerializeField]
		private BattleTypeConstants.CommandSelectType commandSelectType;

		[SerializeField]
		private int defaultScale;
		
		[SerializeField]
		private int addScale;
		
		[Attribute.MessageMethodReceiver( BattleMessageConstants.OpenCommandWindowMessage )]
		void OnOpenCommandWindow( BattleTypeConstants.CommandSelectType type )
		{
			if( type != commandSelectType )	return;
			
			var scale = transform.localScale;
			transform.localScale = new Vector3( scale.x, defaultScale + addScale * ElementCount, scale.z );
		}

		protected abstract int ElementCount{ get; }
	}
}
