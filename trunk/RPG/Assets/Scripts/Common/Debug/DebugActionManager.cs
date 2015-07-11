using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Common
{
	/// <summary>
	/// デバッグアクションコンポーネントを管理するコンポーネント.
	/// </summary>
	public class DebugActionManager : MonoBehaviour
	{
		[System.Serializable]
		public class Data
		{
			public Conditioner Conditioner{ get{ return this.refConditioner; } }
			[SerializeField]
			private Conditioner refConditioner;

			public A_DebugAction DebugAction{ get{ return this.refAction; } }
			[SerializeField]
			private A_DebugAction refAction;
		}

		[SerializeField]
		private List<Data> database;

		void Update()
		{
			for( int i=0, imax=this.database.Count; i<imax; i++ )
			{
				var data = this.database[i];
				if( data.Conditioner.Condition )
				{
					data.DebugAction.Action();
				}
			}
		}
	}
}
