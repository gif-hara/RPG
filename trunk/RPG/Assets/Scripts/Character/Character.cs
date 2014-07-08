/*===========================================================================*/
/*
*     * FileName    : Character.cs
*
*     * Description : キャラクタークラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections;

public abstract class Character
{
	/// <summary>
	/// キャラクタータイプ.
	/// </summary>
	public enum CharacterType : int
	{
		Player = 0,
		Enemy,
	};

	/// <summary>
	/// キャラクターデータ.
	/// </summary>
	protected CharacterData data;
	
	/// <summary>
	/// コンストラクタ
	/// Initializes a new instance of the <see cref="Character"/> class.
	/// </summary>
	/// <param name='_name'>
	/// _name.
	/// </param>
	public Character( int _id )
	{
		InitParam( _id );
	}
	
	public int ID
	{
		get
		{
			return data.id;
		}
	}
	public string Name
	{
		get
		{
			return data.name;
		}
	}
	/// <summary>
	/// ダメージ処理.
	/// </summary>
	/// <param name='damage'>
	/// Damage.
	/// </param>
	public void Damage( int damage )
	{
		data.hitPoint -= damage;
		Debug.Log( data.name + " : HP = " + data.hitPoint + "/" + data.maxHitPoint );
	}
	/// <summary>
	/// 死亡しているか？.
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance is dead; otherwise, <c>false</c>.
	/// </returns>
	public bool IsDead
	{
		get
		{
			return data.hitPoint <= 0;
		}
	}
	
	protected abstract void InitParam( int id );
	
}
/* End of file ==============================================================*/
