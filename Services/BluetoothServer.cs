using System;
using BluetoothMaui.Core;
using BluetoothMaui.Services.Interfaces;
using Shiny.BluetoothLE.Hosting;

namespace BluetoothMaui.Services
{
	public class BluetoothServer : IBluetoothServer
	{
		private readonly IBleHostingManager _bleHostingManager;
		private IGattService _gattService;

		public BluetoothServer(IBleHostingManager bleHostingManager)
		{
			_bleHostingManager = bleHostingManager;
		}

		private async Task CreateService()
		{
			_gattService = await _bleHostingManager.AddService(AppConstants.SERVICE_UUID, true, builder =>
			{

			});
		}

		public bool Started => _bleHostingManager.IsAdvertising; 

		public void Start()
		{
			if (Started)
				return;

		}

		public void Stop()
		{
			throw new NotImplementedException();
		}
	}
}

