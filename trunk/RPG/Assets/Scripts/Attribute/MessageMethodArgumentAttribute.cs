using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Attribute
{
	/// <summary>
	/// メッセージ関数の引数の型を示す属性.
	/// </summary>
	public class MessageMethodArgument : System.Attribute
	{
		public MessageMethodArgument( System.Type type )
		{

		}
	}
}
