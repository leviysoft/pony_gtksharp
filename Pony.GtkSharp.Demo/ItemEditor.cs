﻿using System;
using Pony.Views;

namespace Pony.GtkSharp.Demo
{
	public partial class ItemEditor : View<Item>, IView<Item>
	{
		public ItemEditor(IPonyApplication ponyApplication) : base(ponyApplication)
		{
			this.Build ();
		}


	}
}
