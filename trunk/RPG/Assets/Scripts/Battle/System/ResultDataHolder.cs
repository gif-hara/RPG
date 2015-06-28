using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// バトルの結果データを保持しておくコンポーネント.
	/// </summary>
	public class ResultDataHolder : A_Singleton<ResultDataHolder>
	{
		public ResultData Data{ private set; get; }

		void Awake()
		{
			Instance = this;
		}

		void OnStartBattle()
		{
			this.Data = new ResultData();
		}
	}
}
