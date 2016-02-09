using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Midi;

namespace ConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			int delay = 4;
			OutputDevice outputDevice = OutputDevice.InstalledDevices[0];
			if (outputDevice == null)
			{
				Console.WriteLine("No output devices, so can't run this example.");
				return;
			}
			outputDevice.Open();

			Console.WriteLine("Playing random MIDI");

			Random r = new Random();

			while (true)
			{
				int pitch = r.Next((int)Pitch.C3 - 1, (int)Pitch.B3);

				if (pitch == (int)(Pitch.C3 - 1))
				{
					Thread.Sleep(1000 / delay);
				}
				else
				{
					outputDevice.SendNoteOn(Channel.Channel1, (Pitch)pitch, 80);

					Thread.Sleep(1000 / delay);
					outputDevice.SendNoteOff(Channel.Channel1, (Pitch)pitch, 80);
				}
			}

		}
	}
}
