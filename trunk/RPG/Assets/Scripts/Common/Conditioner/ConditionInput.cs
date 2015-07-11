using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Common
{
	/// <summary>
	/// キー入力が行われているか返すコンポーネント.
	/// </summary>
	public class ConditionInput : Conditioner
	{
		public enum GetKeyType : int
		{
			Down,
			Up,
			Pressing,
		}

		[SerializeField]
		private GetKeyType type;

		[SerializeField]
		private KeyCode keyCode;

		public override bool Condition
		{
			get
			{
				if( this.type == GetKeyType.Down )
				{
					return Input.GetKeyDown( this.keyCode );
				}
				if( this.type == GetKeyType.Up )
				{
					return Input.GetKeyUp( this.keyCode );
				}

				return Input.GetKey( this.keyCode );
			}
		}
	}
}
