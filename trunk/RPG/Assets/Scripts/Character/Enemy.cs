/*===========================================================================*/
/*
*     * FileName    : Enemy.cs
*
*     * Description : 敵クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections;

public class Enemy : Character
{
	public Enemy( int _id )
		:base( _id )
	{
	}
	
	protected override void InitParam ( int id )
	{
		data = Define.GetEnemyData( id );
	}
}
/* End of file ==============================================================*/
