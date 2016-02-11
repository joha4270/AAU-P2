using Midi;

namespace libmusic
{
	public class InfoObject
	{
		private DeviceBase _device;
		public Channel Channel;
		private Clock _clock;

		internal InfoObject(GeneratorFramework generatorFramework, OutputDevice device, Clock clock)
		{
			Device = device;
			Clock = clock;

		}


		public OutputDevice Device { get;  }

		public Clock Clock { get; }
	}
}