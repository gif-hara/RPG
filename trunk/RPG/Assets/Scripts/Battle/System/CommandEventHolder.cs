/*===========================================================================*/
/*
*     * FileName    : CommandEventHolder.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドイベントデータを保持するコンポーネント.
	/// </summary>
	public class CommandEventHolder : MyMonoBehaviour
	{
		[System.Serializable]
		public class Element
		{
			public CommandEventConstants.EventName EventName{ get{ return this.eventName; } }
			[SerializeField]
			private CommandEventConstants.EventName eventName;

			public CommandEventBase CommandEvent{ get{ return this.commandEvent; } }
			[SerializeField]
			private CommandEventBase commandEvent;
		}

		[SerializeField]
		private List<Element> elementList;

		public CommandEventBase Get( CommandEventConstants.EventName eventName )
		{
			return elementList.Find( e => e.EventName == eventName ).CommandEvent;
		}
	}
}
