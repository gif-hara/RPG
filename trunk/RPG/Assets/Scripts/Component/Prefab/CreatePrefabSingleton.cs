using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// シングルトン的なオブジェクトを生成するコンポーネント.
/// </summary>
public class CreatePrefabSingleton : MyMonoBehaviour
{
	[SerializeField]
	private GameObject prefabDontDestroyObject;

	private static bool isCreate = false;

	void Awake()
	{
		if( isCreate )
		{
			Destroy( gameObject );
			return;
		}

		isCreate = true;
		Instantiate( prefabDontDestroyObject, transform );
		DontDestroyOnLoad( gameObject );
	}
}
