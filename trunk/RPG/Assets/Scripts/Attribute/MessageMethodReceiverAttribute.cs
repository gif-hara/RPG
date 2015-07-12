using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Attribute
{
	/// <summary>
	/// メッセージ受信関数であることを示す属性.
	/// </summary>
	public class MessageMethodReceiver : System.Attribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RPG.Attribute.MessageMethodReceiver"/> class.
		/// </summary>
		/// <param name="methodName">定義された関数名.</param>
		public MessageMethodReceiver( string methodName )
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RPG.Attribute.MessageMethodReceiver"/> class.
		/// </summary>
		/// <param name="methodName">定義された関数名.</param>
		/// <param name="parameterType">引数の型.</param>
		public MessageMethodReceiver( string methodName, System.Type parameterType )
		{
			
		}
	}
}
