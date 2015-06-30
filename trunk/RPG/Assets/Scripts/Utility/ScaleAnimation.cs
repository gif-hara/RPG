/*===========================================================================*/
/*
*     * FileName    :ScaleAnimation.cs
*
*     * Description : スケールアニメーションコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class ScaleAnimation : MyMonoBehaviour
{
	[SerializeField]
	private Vector3 from;

	[SerializeField]
	private Vector3 to;

	[SerializeField]
	private AnimationCurve curve;

	[SerializeField]
	private int duration;

	private int currentDuration = 0;

	void Update ()
	{
		transform.localScale = Vector3.Lerp( from, to, curve.Evaluate( (float)currentDuration / (float)duration ) );
		currentDuration++;
	}
}
