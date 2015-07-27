using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Battle
{
	/// <summary>
	/// コマンドイベントに各パラメータを設定可能なインターフェイス.
	/// </summary>
	public interface I_SetCommandEventParameter
	{
		void SetCommandEventParameter( Database.CommandEventData data );
	}
}
