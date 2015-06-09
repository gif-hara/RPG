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
				this.BroadcastMessage( this.refReceiver, CommonMessageConstants.InputLeftMessage );
			}
			if( MyInput.Right )
			{
				this.BroadcastMessage( this.refReceiver, CommonMessageConstants.InputRightMessage );
			}
			if( MyInput.Up )
			{
				this.BroadcastMessage( this.refReceiver, CommonMessageConstants.InputUpMessage );
			}
			if( MyInput.Down )
			{
				this.BroadcastMessage( this.refReceiver, CommonMessageConstants.InputDownMessage );
			}
			if( MyInput.Decide )
			{
				this.BroadcastMessage( this.refReceiver, CommonMessageConstants.InputDecideMessage, SendMessageOptions.DontRequireReceiver );
			}
			if( MyInput.Cancel )
			{
				this.BroadcastMessage( this.refReceiver, CommonMessageConstants.InputCancelMessage, SendMessageOptions.DontRequireReceiver );
			}
		}
	}
}
