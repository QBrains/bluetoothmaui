using System;
namespace BluetoothMaui.Services.Interfaces
{
	public interface IBluetoothServer
	{
		void Start();
		void Stop();
		bool Started { get; }
	}
}

