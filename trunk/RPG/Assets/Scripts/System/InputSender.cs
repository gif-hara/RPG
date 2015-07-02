/*===========================================================================*/
/*
*     * FileName    : InputSender.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Common
{
	/// <summary>
	/// 入力イベントを送信するコンポーネント.
	/// </summary>
	public class InputSender : MyMonoBehaviour
	{
		[SerializeField]
		private GameObject refReceiver;

		// Update is called once per frame
		void Update ()
		{
			if( MyInput.Left )
			{
				this.BroadcastMessage( this.refReceiver, MessageConstants.InputLeftMessage );
			}
			if( MyInput.Right )
			{
				this.BroadcastMessage( this.refReceiver, MessageConstants.InputRightMessage );
			}
			if( MyInput.Up )
			{
				this.BroadcastMessage( this.refReceiver, MessageConstants.InputUpMessage );
			}
			if( MyInput.Down )
			{
				this.BroadcastMessage( this.refReceiver, MessageConstants.InputDownMessage );
			}
			if( MyInput.Decide )
			{
				this.BroadcastMessage( this.refReceiver, MessageConstants.InputDecideMessage, SendMessageOptions.DontRequireReceiver );
			}
			if( MyInput.Cancel )
			{
				this.BroadcastMessage( this.refReceiver, MessageConstants.InputCancelMessage, SendMessageOptions.DontRequireReceiver );
			}
		}
	}
}
