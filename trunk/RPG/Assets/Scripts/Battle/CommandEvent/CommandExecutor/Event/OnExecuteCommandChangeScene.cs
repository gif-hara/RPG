using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時にシーンを切り替えるコンポーネント.
	/// </summary>
	public class OnExecuteCommandChangeScene : MyMonoBehaviour, I_OnExecuteCommandHookable
	{
		[SerializeField]
		private string sceneName;

		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand( MessageConstants.ExecuteCommandHook hook )
		{
			Application.LoadLevel( sceneName );
		}
	}
}
