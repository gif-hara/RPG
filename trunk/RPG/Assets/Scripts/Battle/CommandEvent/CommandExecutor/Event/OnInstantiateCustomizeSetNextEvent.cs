using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// プレハブ生成時にコマンドイベントの次のイベントを設定する.
	/// </summary>
	public class OnInstantiateCustomizeSetNextEvent : MonoBehaviour
	{
		[SerializeField]
		private GameObject refEventHolder;

		[Attribute.MessageMethodReceiver( Battle.MessageConstants.InstantiateCustomizeMessage )]
		void OnInstantiateCustomize( GameObject obj )
		{
			var setNextEvent = obj.GetComponent( typeof( OnExecuteCommandSetNextEvent ) ) as OnExecuteCommandSetNextEvent;

			Debug.Assert( setNextEvent != null, "OnExecuteCommandSetNextEventがありませんでした." );

			setNextEvent.SetEventHolder( this.refEventHolder );
		}
	}
}
