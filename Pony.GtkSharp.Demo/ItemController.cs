using System;
using Pony.ControllerInterfaces;
using Pony.GtkSharp.Demo.Domain;
using Pony.Views;

namespace Pony.GtkSharp.Demo
{
	public class ItemController : ICanCreate<Item>, IHandlesErrors<Item>
	{
		public OperationResult<Item> Create (IView<Item> view)
		{
			return OperationResult.Produce(OperationStatus.Completed, view.Model);
		}
			
		public OperationResult<Item> OnError (IView<Item> view)
		{
			return OperationResult.Produce(OperationStatus.Cancelled, view.Model);
		}
	}
}

