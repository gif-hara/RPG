/*===========================================================================*/
/*
*     * FileName    : WorldMapData.cs
*
*     * Description : ワールドマップデータクラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections;

public class WorldMapData : MonoBehaviour
{
	/// <summary>
	/// ワールドマップの横座標.
	/// </summary>
	private static int worldMapPositionH;
	
	/// <summary>
	/// ワールドマップの縦座標.
	/// </summary>
	private static int worldMapPositionV;
	
	/// <summary>
	/// ワールドマップの座標を設定.
	/// セルIDで設定するように.
	/// </summary>
	/// <param name='horizontal'>
	/// Horizontal.
	/// </param>
	/// <param name='vertical'>
	/// Vertical.
	/// </param>
	public static void SetWorldPosition( int horizontal, int vertical )
	{
		worldMapPositionH = horizontal;
		worldMapPositionV = vertical;
	}
	
	public static void AddWorldPosition( int horizontal, int vertical )
	{
		worldMapPositionH += horizontal;
		worldMapPositionV += vertical;
	}
	/// <summary>
	/// ワールドマップ座標のワールド座標を返す.
	/// </summary>
	/// <value>
	/// The world map position.
	/// </value>
	public static Vector3 WorldMapPosition
	{
		get
		{
			return new Vector3(
				( WorldMapCellManager.SplitHorizontal * worldMapPositionH ) + WorldMapCellManager.SplitHorizontal / 2.0f,
				0.0f,
				( WorldMapCellManager.SplitVertical * worldMapPositionV ) + WorldMapCellManager.SplitVertical / 2.0f
				);
		}
	}
}
/* End of file ==============================================================*/
