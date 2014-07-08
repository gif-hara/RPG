/*===========================================================================*/
/*
*     * FileName    : PlayData.cs
*
*     * Description : プレイデータクラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections.Generic;

public class PlayData : MonoBehaviour
{
	/// <summary>
	/// パーティリスト.
	/// </summary>
	private static List<Player> party;
	
	public static List<Player> Party
	{
		get
		{
			party = party ?? InitParty;
			
			return party;
		}
	}
	/// <summary>
	/// パーティ配列がnullの時の初期パーティを返す.
	/// </summary>
	/// <value>
	/// The init party.
	/// </value>
	private static List<Player> InitParty
	{
		get
		{
			List<Player> result = new List<Player>();
			result.Add( new Player( 0 ) );
			result.Add( new Player( 1 ) );
			result.Add( new Player( 2 ) );
			//result.Add( new Player( 3 ) );
			
			return result;
		}
	}
}
/* End of file ==============================================================*/
