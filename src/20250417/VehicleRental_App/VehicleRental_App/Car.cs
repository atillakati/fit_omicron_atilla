

namespace VehicleRental_App
{
    public class Car : Vehicle
    {
		private int _seatCount;

        public Car(string description, string brand, int enginePower, int maxSpeed, int seatCount)
            : base(description, brand, enginePower, maxSpeed)
        {
            _seatCount = seatCount;
        }

        public int SeatCount
		{
			get { return _seatCount; }		
		}

	}
}
