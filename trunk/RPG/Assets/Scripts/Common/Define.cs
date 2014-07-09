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
	
	private static CharacterData[] playerData = null;
	
	private static CharacterData[] enemyData = null;
	
	/// <summary>
	/// プレイヤーの名前を返す.
	/// </summary>
	/// <returns>
	/// The player name.
	/// </returns>
	/// <param name='id'>
	/// Identifier.
	/// </param>
	public static CharacterData GetPlayerData( int id )
	{
		playerData = playerData ?? GetCharacterData( "Data/PlayerData" );
		
		return playerData[id];
	}
	/// <summary>
	/// 敵の名前を返す.
	/// </summary>
	/// <returns>
	/// The enemy name.
	/// </returns>
	/// <param name='id'>
	/// Identifier.
	/// </param>
	public static CharacterData GetEnemyData( int id )
	{
		enemyData = enemyData ?? GetCharacterData( "Data/EnemyData" );
		return enemyData[id];
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
	
	private static CharacterData[] GetCharacterData( string path )
	{
		TextAsset asset = (TextAsset)Resources.Load( path );
		string[] split = asset.text.Split( new string[]{ System.Environment.NewLine }, System.StringSplitOptions.None );
		List<CharacterData> result = new List<CharacterData>();
		int id = 0;
		
		for( int i=0,imax=split.Length; i<imax; i++ )
		{
			string s = split[i];
			if( s.IndexOf( "//" ) != -1 )	continue;
			
			CharacterData c = new CharacterData( id );
			c.Initialize( s );
			result.Add( c );
			id++;
		}
		
		return result.ToArray();
	}
	/// <summary>
	/// テキストファイルを改行分割した配列にして返す.
	/// </summary>
	/// <returns>
	/// The split data.
	/// </returns>
	/// <param name='path'>
	/// Path.
	/// </param>
	private static string[] GetSplitData( string path )
	{
		TextAsset asset = (TextAsset)Resources.Load( path );
		return asset.text.Split( new string[]{ System.Environment.NewLine }, System.StringSplitOptions.None );
	}
}
/* End of file ==============================================================*/
