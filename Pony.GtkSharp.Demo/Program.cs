using System;
using StructureMap;
using Pony.ControllerInterfaces;
using Pony.Serialization;
using Pony.StructureMap;
using Pony.Views;
using StructureMap.Graph;
using Pony.DI;

namespace Pony.GtkSharp.Demo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Gtk.Application.Init ();

			var structureMapContainer = new Container(cfg =>
			{
				cfg.Scan(scan =>
					{
						scan.AssembliesFromApplicationBaseDirectory();
						scan.TheCallingAssembly();
						scan.AddAllTypesOf<IView>();
						scan.AddAllTypesOf(typeof (IView<>));
						scan.AddAllTypesOf(typeof (ICanCreate<>));
						scan.AddAllTypesOf(typeof (ICanEdit<>));
						scan.AddAllTypesOf(typeof (IHandlesErrors<>));
						scan.AddAllTypesOf(typeof (IHandlesAbort<>));
						scan.AddAllTypesOf(typeof (IHandlesCancel<>));
						scan.AddAllTypesOf(typeof (IHandlesIgnore<>));
						scan.AddAllTypesOf(typeof (IHandlesRetry<>));
						scan.AddAllTypesOf(typeof (ISerializer<>));
					});
                    cfg.For<IPonyApplication>().Use<PonyApplication>();
                    cfg.For<IPonyContainer>().Use<StructureMapPonyContainer>();
			});

            var demoApp = structureMapContainer.GetInstance<IPonyApplication>();
			demoApp.Show<MainWindow> ();
	
			Gtk.Application.Run ();
		}
	}
}
