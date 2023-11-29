using System;
using Autofac;
using BluetoothMaui.Services;
using BluetoothMaui.Services.Interfaces;
using AutofacIContainer = Autofac.IContainer;

namespace BluetoothMaui.Core
{
	public static class Resolver
	{
		private static Dictionary<Type, object> _additionalServices = new();
		private static AutofacIContainer _container;

		public static void AddOnStartup<T>(object service)
		{
			if(_additionalServices.ContainsKey(typeof(T)))
			{
				_additionalServices.Remove(typeof(T));
			}
			_additionalServices.Add(typeof(T), service);
		}

		public static void Build()
		{
			ContainerBuilder builder = new();
			foreach(Type t in _additionalServices.Keys)
			{
				object service = _additionalServices[t];
				builder.RegisterType(service.GetType()).As(t).SingleInstance();
			}

			builder.RegisterType<SoftwareVersion>().As<ISoftwareVersion>();

			_container = builder.Build();
		}

		public static T Resolve<T>()
		{
			return _container.Resolve<T>();
		}
	}
}

