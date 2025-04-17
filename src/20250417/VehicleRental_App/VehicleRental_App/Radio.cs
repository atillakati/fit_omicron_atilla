using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental_App
{
    public class Radio
    {
		private PowerState _state;
		private string _stationName;
		private int _volume;

        public Radio()
        {
			_stationName = "Classic Radio Station";
			_volume = 5;
			_state = PowerState.Off;
        }

        public int Volume
		{
			get { return _volume; }
			set 
			{
				if (value <= 10 || value >= 0)
				{
					_volume = value;
				}
            }
		}

		public string StationName
		{
			get { return _stationName; }
			set { _stationName = value; }
		}

		public PowerState State
		{
			get { return _state; }			
		}

		public void ChangeState(PowerState newState)
		{
			if (_state != PowerState.Locked)
			{
				_state = newState;
			}
		}

		public void Play()
		{
			var message = $"Just making some noise on '{_stationName}'";

			if(_volume > 8)
			{
				message = message.ToUpper();
			}
			else if(_volume < 3)
			{
                message = message.ToLower();
            }

            Console.WriteLine(message);
		}
	}
}
