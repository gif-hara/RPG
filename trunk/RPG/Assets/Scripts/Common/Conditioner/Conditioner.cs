using UnityEngine;
using System.Collections.Generic;

namespace RPG.Common
{
	/// <summary>
	/// 何かしらの条件を返す抽象コンポーネント.
	/// </summary>
	public abstract class Conditioner : MyMonoBehaviour
	{
		public abstract bool Condition{ get; }
	}
}
