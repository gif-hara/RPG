/*===========================================================================*/
/*
*     * FileName    : FactoryElement.cs
*
*     * Description : ファクトリー要素.
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
	/// ファクトリー要素.
	/// </summary>
	public abstract class FactoryElement
	{
		public int Id{ private set; get; }

		public FactoryElement( int id )
		{
			this.Id = id;
		}

		public abstract FactoryElement Clone();
	}
}
