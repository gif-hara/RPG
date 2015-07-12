using UnityEngine;
using System.Collections.Generic;

namespace RPG.Common
{
	/// <summary>
	/// 共通して使用されるタイプ定義.
	/// </summary>
	public class TypeConstants
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

		[System.Flags]
		public enum AbnormalStateType
		{
			Paralysis = 1 << 0,
			Poison    = 1 << 1,
		}

		public const string ChangeSceneMessage = "OnChangeScene";
	}
}
