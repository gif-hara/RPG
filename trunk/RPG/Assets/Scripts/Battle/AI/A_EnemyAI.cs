using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Battle
{
	/// <summary>
	/// 敵のAI抽象コンポーネント.
	/// </summary>
	public abstract class A_EnemyAI : MyMonoBehaviour
	{
		public abstract void Think( Enemy enemy );
	}
}
