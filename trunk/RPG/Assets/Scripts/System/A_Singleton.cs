/*===========================================================================*/
/*
*     * FileName    : A_Singleton.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

namespace RPG.Common
{
	public class A_Singleton<T> : MyMonoBehaviour where T : MonoBehaviour
	{
		private static T instance = null;
			
		public static T Instance
		{
			protected set
			{
				instance = value;
			}
			get
			{
				return instance;
			}
		}
	}
}