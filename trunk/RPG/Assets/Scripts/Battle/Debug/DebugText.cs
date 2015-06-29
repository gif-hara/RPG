using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RPG.Common
{
	/// <summary>
	/// デバッグ用テキストコンポーネント.
	/// </summary>
	public class DebugText : A_Singleton<DebugText>
	{
		[SerializeField]
		private Text refText;

		void Awake()
		{
			Instance = this;
		}

		void OnRenderObject()
		{
			refText.text = "";
		}

		void OnDestroy()
		{
			Instance = null;
		}

		public void AppendLine( string message )
		{
			refText.text += System.Environment.NewLine + message;
		}
	}
}
