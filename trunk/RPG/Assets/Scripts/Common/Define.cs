/*===========================================================================*/
/*
*     * FileName    : Define.cs
*
*     * Description : 各種定義クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

public class Define : MonoBehaviour
{
	public enum RotateType : int
	{
		Forward = 0,
		Right = 1,
		Back = 2,
		Left = 3,
	}
	
	/// <summary>
	/// プレイヤーモデルを返す.
	/// </summary>
	/// <returns>
	/// The player model.
	/// </returns>
	/// <param name='id'>
	/// Identifier.
	/// </param>
	public static GameObject GetPlayerModel( int id )
	{
		string path = string.Format( "Model/Player/Player{0}", id );
		return Resources.Load<GameObject>( path );
	}
	/// <summary>
	/// 敵モデルを返す.
	/// </summary>
	/// <returns>
	/// The enemy model.
	/// </returns>
	/// <param name='id'>
	/// Identifier.
	/// </param>
	public static GameObject GetEnemyModel( int id )
	{
		string path = string.Format( "Model/Enemy/Enemy{0}", id );
		return Resources.Load<GameObject>( path );
	}
	
}
/* End of file ==============================================================*/
