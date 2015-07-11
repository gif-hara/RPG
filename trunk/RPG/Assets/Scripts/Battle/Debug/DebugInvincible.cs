using UnityEngine;
using System.Collections.Generic;
using RPG;
using RPG.Framework;

namespace RPG.Battle
{
	/// <summary>
	/// 敵味方を無敵状態にするデバッグコンポーネント.
	/// </summary>
	public class DebugInvincible : Common.A_DebugAction
	{
		public override void Action ()
		{
			DebugData.isInvincible = !DebugData.isInvincible;
			Debug.Log( string.Format( "{0}Invincible = {1}", LiveConsoleLogAttribute.Get( LiveConsoleLogAttribute.Attribute.Debug ), DebugData.isInvincible ) );
		}
	}
}
