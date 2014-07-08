/*===========================================================================*/
/*
*     * FileName    : EncountManager.cs
*
*     * Description : エンカウント管理者クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

//#define NOT_ENCOUNT	// エンカウントをしない.

using UnityEngine;
using System.Collections;

public class EncountManager : MonoBehaviour
{
	/// <summary>
	/// エンカウント確率.
	/// </summary>
	private int probability = 0;
	
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
	}
	/// <summary>
	/// エンカウント率の上昇.
	/// </summary>
	public void AddProbability()
	{
		probability += 5;
	}
	/// <summary>
	/// エンカウント処理.
	/// </summary>
	public bool Encount()
	{
#if NOT_ENCOUNT
		return false;
#endif
		
		if( IsEncount() )
		{
			Application.LoadLevel( "Battle" );
			return true;
		}
		
		return false;
	}
	
	private bool IsEncount()
	{
		int rnd = Random.Range( 0, probability );
		DebugSystem.Log( rnd );
		return rnd > 50;
	}
}
/* End of file ==============================================================*/
