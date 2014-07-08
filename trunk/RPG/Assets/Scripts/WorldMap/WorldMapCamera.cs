/*===========================================================================*/
/*
*     * FileName    : WorldMapCamera.cs
*
*     * Description : ワールドマップカメラクラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections;

public class WorldMapCamera : MonoBehaviour
{
	/// <summary>
	/// オブジェクト参照.
	/// </summary>
	public GameObject refTargetObject;
	
	public float rotationX = 30.0f;
	
	public float distance = -10.0f;
	
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void LateUpdate()
	{
		transform.rotation = Quaternion.AngleAxis( rotationX, Vector3.right );
		iTween.MoveUpdate( gameObject, iTween.Hash(
			"position", TargetPosition,
			"time", 0.5f 
			)
			);
	}
	
	private Vector3 TargetPosition
	{
		get
		{
			Vector3 targetPosition = refTargetObject.transform.position;
			Vector3 interval = transform.forward * distance;
			
			return targetPosition + interval;
		}
	}
}
/* End of file ==============================================================*/
