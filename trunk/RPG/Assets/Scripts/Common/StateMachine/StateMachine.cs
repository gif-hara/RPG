﻿/*===========================================================================*/
/*
*     * FileName    : StateMachine.cs
*
*     * Description : ステートマシン.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Common
{
	/// <summary>
	/// ステートマシン.
	/// </summary>
	public class StateMachine<TOwner> where TOwner : class
	{
		private TOwner owner;

		private List<StateElementBase<TOwner>> elementList;

		private StateElementBase<TOwner> currentElement;

		public StateMachine( TOwner owner )
		{
			this.owner = owner;
			this.elementList = new List<StateElementBase<TOwner>>();
		}

		public void Add( StateElementBase<TOwner> element ) 
		{
			this.elementList.Add( element );
		}

		public void Change( int id )
		{
			if( this.currentElement != null )
			{
				this.currentElement.Exit( owner );
			}

			this.currentElement = this.elementList.Find( e => e.ID == id );
			if( this.currentElement == null )
			{
				Debug.LogException( new System.ArgumentException( string.Format( "id={0} のElementが存在しません.", id ) ) );
			}
			this.currentElement.Enter( owner );
		}

		public void ClearElement()
		{
			this.currentElement = null;
		}

		public void Update()
		{
			this.currentElement.Update( owner );
		}

		public int CurrentElementId
		{
			get
			{
				return this.currentElement.ID;
			}
		}
	}
}
