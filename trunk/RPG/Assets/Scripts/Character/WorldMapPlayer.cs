/*===========================================================================*/
/*
*     * FileName    : WorldMapPlayer.cs
*
*     * Description : ワールドマップ移動時のプレイヤークラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections;

public class WorldMapPlayer : MonoBehaviour
{
	/// <summary>
	/// エンカウント管理者参照.
	/// </summary>
	public EncountManager refEncountManager;
	
	/// <summary>
	/// 移動可能であるか？.
	/// </summary>
	private bool isMove = true;
	
	// Use this for initialization
	void Start()
	{
		transform.position = WorldMapData.WorldMapPosition;
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
	
	void LateUpdate()
	{
		InputMove();
	}
	/// <summary>
	/// キー入力による移動処理.
	/// </summary>
	private void InputMove()
	{
		if( !isMove )	return;
		
		if( Input.GetKey( KeyCode.LeftArrow ) )
		{
			Move( Define.RotateType.Left );
		}
		else if( Input.GetKey( KeyCode.RightArrow ) )
		{
			Move( Define.RotateType.Right );
		}
		else if( Input.GetKey( KeyCode.UpArrow ) )
		{
			Move( Define.RotateType.Forward );
		}
		else if( Input.GetKey( KeyCode.DownArrow ) )
		{
			Move( Define.RotateType.Back );
		}
	}
	/// <summary>
	/// 移動処理.
	/// </summary>
	/// <param name='type'>
	/// Type.
	/// </param>
	private void Move( Define.RotateType type )
	{
		int horizontal = type == Define.RotateType.Left ? -1 : type == Define.RotateType.Right ? 1 : 0;
		int vertical = type == Define.RotateType.Forward ? 1 : type == Define.RotateType.Back ? -1 : 0;
		WorldMapData.AddWorldPosition( horizontal, vertical );
		StartMove();
		SetRotate( type );
	}
	/// <summary>
	/// 向きの設定.
	/// </summary>
	/// <param name='type'>
	/// Type.
	/// </param>
	private void SetRotate( Define.RotateType type )
	{
		float angle = (int)type * 90.0f;
		transform.rotation = Quaternion.AngleAxis( angle, Vector3.up );
	}
	/// <summary>
	/// 移動開始処理.
	/// </summary>
	private void StartMove()
	{
		iTween.MoveTo( gameObject, iTween.Hash(
			"position", WorldMapData.WorldMapPosition,
			"time", 0.3f,
			"oncomplete", "EndMove",
			"easetype", iTween.EaseType.linear
			)
			);
		isMove = false;
	}
	/// <summary>
	/// 移動終了処理.
	/// </summary>
	private void EndMove()
	{
		refEncountManager.AddProbability();
		transform.position = WorldMapData.WorldMapPosition;
		bool isEncount = refEncountManager.Encount();
		
		isMove = !isEncount;
	}
}
/* End of file ==============================================================*/
