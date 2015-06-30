using UnityEngine;
using System.Collections.Generic;

namespace RPG.Common
{
	/// <summary>
	/// 共通して使用されるタイプ定義.
	/// </summary>
	public class CommonDefine
	{
		public enum CreateType : int
		{
			Instantiate,
			Pool,
		}

		public enum UpdateType : int
		{
			Update,
			LateUpdate,
		}

		public enum WorldSpaceType : int
		{
			World,
			Local,
		}

		public const string ChangeSceneMessage = "OnChangeScene";
	}
}
