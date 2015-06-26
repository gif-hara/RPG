using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドイベントを仲介するコンポーネント.
	/// </summary>
	public class CommandEventMediator : MonoBehaviour
	{
		[SerializeField]
		private GameObject refEventHolder;

		public void SetEvent( CommandExecuter commandExecuter )
		{
			this.transform.parent = commandExecuter.transform;
			commandExecuter.InsertEventHolder( this.refEventHolder );
		}
	}
}
