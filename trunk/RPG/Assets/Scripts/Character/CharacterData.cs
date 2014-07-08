/*===========================================================================*/
/*
*     * FileName    : CharacterData.cs
*
*     * Description : キャラクターデータクラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections;

public class CharacterData
{
	/// <summary>
	/// ID.
	/// </summary>
	public int id;
	
	/// <summary>
	/// 名前.
	/// </summary>
	public string name;
	
	/// <summary>
	/// 段.
	/// </summary>
	public int level;
	
	/// <summary>
	/// 最大体力.
	/// </summary>
	public int maxHitPoint;
	
	/// <summary>
	/// 体力.
	/// </summary>
	public int hitPoint;
	
	/// <summary>
	/// 最大技量.
	/// </summary>
	public int maxMagicPoint;
	
	/// <summary>
	/// 技量.
	/// </summary>
	public int magicPoint;
	
	/// <summary>
	/// 攻撃力.
	/// </summary>
	public int strength;
	
	/// <summary>
	/// 防御力.
	/// </summary>
	public int defence;
	
	/// <summary>
	/// 素早さ.
	/// </summary>
	public int speed;
	
	/// <summary>
	/// 回避率.
	/// </summary>
	public int avoid;
	
	public CharacterData( int _id )
	{
		id = _id;
	}
	
	public void Initialize( string data )
	{
//		Debug.Log( data );
		
		string[] split = data.Split( ',' );
		name = split[0];
		hitPoint = int.Parse( split[1] );
		magicPoint = int.Parse( split[2] );
		strength = int.Parse( split[3] );
		defence = int.Parse( split[4] );
		speed = int.Parse( split[5] );
		avoid = int.Parse( split[6] );
		
		maxHitPoint = hitPoint;
		maxMagicPoint = magicPoint;
	}
}
/* End of file ==============================================================*/
