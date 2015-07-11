using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Common
{
	/// <summary>
	/// デバッグを行う抽象コンポーネント.
	/// </summary>
	public abstract class A_DebugAction : MonoBehaviour
	{
		public abstract void Action();
	}
}
