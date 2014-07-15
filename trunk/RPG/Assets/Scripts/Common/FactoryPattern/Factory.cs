/*===========================================================================*/
/*
*     * FileName    : Factory.cs
*
*     * Description : ファクトリーパターン.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Common
{
	/// <summary>
	/// ファクトリーパターン.
	/// </summary>
	public class Factory<T> where T : FactoryElement
	{
		private List<T> productList;

		public Factory()
		{
			this.productList = new List<T>();
		}

		public void Add( T product )
		{
			this.productList.Add( product );
		}

		public T Clone( int id )
		{
			return productList.Find( p => p.Id == id ).Clone() as T;
		}
	}
}
