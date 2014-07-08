/*===========================================================================*/
/*
*     * FileName    : Player.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections;

public class Player : Character
{
	public Player( int _id )
		: base( _id )
	{
	}
	
	protected override void InitParam (int id)
	{
		data = Define.GetPlayerData( id );
	}
}
/* End of file ==============================================================*/
