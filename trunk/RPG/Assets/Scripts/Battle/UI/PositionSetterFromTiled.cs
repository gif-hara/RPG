/*===========================================================================*/
/*
*     * FileName    : PositionSetterFromTiled.cs
*
*     * Description : 座標をタイル式に設定していくコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Common
{
	/// <summary>
	/// 座標をタイル式に設定していくコンポーネント.
	/// </summary>
	public class PositionSetterFromTiled : MyMonoBehaviour
	{
		/// <summary>
		/// 座標設定方式.
		/// </summary>
		public enum PositionType : int
		{
			/// <summary>
			/// 余剰分を加算する.
			/// </summary>
			Surplus,
			/// <summary>
			/// 除算分を加算する.
			/// </summary>
			Division,
		}

		[SerializeField]
		private RectTransform refRectTransform;

		[SerializeField]
		private PositionType xPositionType;

		[SerializeField]
		private PositionType yPositionType;

		[SerializeField]
		private int split;

		[SerializeField]
		private Vector2 interval;

		/// <summary>
		/// 原点座標.
		/// </summary>
		private Vector3 originPosition;

		/// <summary>
		/// 初期化したか.
		/// </summary>
		private bool isInitialize = false;

		void Awake()
		{
			Initialize();
		}

		protected void Set( int id )
		{
			var x = xPositionType == PositionType.Surplus
				? interval.x * (id % split)
					: interval.x * (id / split);
			var y = yPositionType == PositionType.Surplus
				? interval.y * (id % split)
					: interval.y * (id / split);
			this.refRectTransform.anchoredPosition = originPosition + new Vector3( x, y, 0.0f );
		}

		private void Initialize()
		{
			if( this.isInitialize )	return;

			this.isInitialize = true;
			this.originPosition = this.refRectTransform.anchoredPosition;
		}
	}
}
