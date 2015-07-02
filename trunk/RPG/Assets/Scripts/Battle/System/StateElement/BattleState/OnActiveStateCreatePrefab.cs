using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// ステートがアクティブになった際にプレハブを生成するコンポーネント.
	/// </summary>
	public class OnActiveStateCreatePrefab : MyMonoBehaviour
	{
		[SerializeField]
		private GameObject prefab;
		
		[Attribute.MessageMethodReceiver( MessageConstants.ActiveStateMessage )]
		void OnActiveState()
		{
			Instantiate( prefab, transform );
		}
	}
}
