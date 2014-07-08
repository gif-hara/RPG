/*===========================================================================*/
/*
*     * FileName    : WorldMapCellManager.cs
*
*     * Description : ワールドマップセル管理クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections;

public class WorldMapCellManager : MonoBehaviour
{
	/// <summary>
	/// 横方向の最大値.
	/// </summary>
	private const int MaxHorizontal = 2000;
	
	/// <summary>
	/// 縦方向の最大値.
	/// </summary>
	private const int MaxVertical = 2000;

	/// <summary>
	/// 横方向のセル最大値.
	/// </summary>
	private const int MaxCellNumH = 1000;
	
	/// <summary>
	/// 縦方向のセル最大値.
	/// </summary>
	private const int MaxCellNumV = 1000;

	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
	}
	
	void OnDrawGizmos()
	{
		for( int i=0; i<MaxCellNumH; i++ )
		{
			float currentHorizontal = SplitHorizontal * i;
			Gizmos.DrawLine( new Vector3( 0.0f, 0.0f, currentHorizontal ), new Vector3( 2000.0f, 0.0f, currentHorizontal ) );
		}
		for( int i=0; i<MaxCellNumV; i++ )
		{
			float currentVertical = SplitVertical * i;
			Gizmos.DrawLine( new Vector3( currentVertical, 0.0f, 0.0f ), new Vector3( currentVertical, 0.0f, 2000.0f ) );
		}
	}
	/// <summary>
	/// 分割された横セルの大きさを返す.
	/// </summary>
	/// <value>
	/// The split horizontal.
	/// </value>
	public static int SplitHorizontal
	{
		get
		{
			return MaxHorizontal / MaxCellNumH;
		}
	}
	/// <summary>
	/// 分割された縦セルの大きさを返す.
	/// </summary>
	/// <value>
	/// The split vertical.
	/// </value>
	public static int SplitVertical
	{
		get
		{
			return MaxVertical / MaxCellNumV;
		}
	}
}
/* End of file ==============================================================*/
