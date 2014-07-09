/*===========================================================================*/
/*
*     * FileName    : StateElementBase.cs
*
*     * Description : ステートマシンの要素抽象クラス.
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
	/// ステートマシンの要素抽象クラス.
	/// </summary>
	public abstract class StateElementBase<TOwner> where TOwner : class
	{
		public int ID{ private set; get; }

		public StateElementBase( int id )
		{
			this.ID = id;
		}
		/// <summary>
		/// 初期化処理.
		/// </summary>
		/// <param name="owner">Owner.</param>
		public abstract void Enter( TOwner owner );

		/// <summary>
		/// 更新処理.
		/// </summary>
		/// <param name="owner">Owner.</param>
		public abstract void Update( TOwner owner );

		/// <summary>
		/// 終了処理.
		/// </summary>
		/// <param name="owner">Owner.</param>
		public abstract void Exit( TOwner owner );
	}
}
