using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時にシーンを切り替えるコンポーネント.
	/// </summary>
	public class OnExecuteCommandChangeScene : MyMonoBehaviour
	{
		[SerializeField]
		private string sceneName;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand( BattleMessageConstants.ExecuteCommandHook hook )
		{
			Application.LoadLevel( sceneName );
		}
	}
}
