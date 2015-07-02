using UnityEngine;
using System.Collections.Generic;

namespace RPG.Common
{
	/// <summary>
	/// 共通で使用するメッセージ定数定義.
	/// </summary>
	public static class MessageConstants
	{
		/// <summary>
		/// 左キーが押された際のメッセージ
		/// </summary>
		public const string InputLeftMessage = "OnInputLeft";
		
		/// <summary>
		/// 右キーが押された際のメッセージ
		/// </summary>
		public const string InputRightMessage = "OnInputRight";
		
		/// <summary>
		/// 上キーが押された際のメッセージ
		/// </summary>
		public const string InputUpMessage = "OnInputUp";
		
		/// <summary>
		/// 下キーが押された際のメッセージ
		/// </summary>
		public const string InputDownMessage = "OnInputDown";
		
		/// <summary>
		/// 決定キーが押された際のメッセージ
		/// </summary>
		public const string InputDecideMessage = "OnInputDecide";
		
		/// <summary>
		/// キャンセルキーが押された際のメッセージ
		/// </summary>
		public const string InputCancelMessage = "OnInputCancel";
		
	}
}
