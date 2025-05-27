using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental_App
{
    public class Scooter : Vehicle
    {
		private double _weight;
        private int _stateOfCharge;

        public Scooter(string description, string brand, int enginPower, int maxSpeed, double weight)
            : base(description, brand, enginPower, maxSpeed)
        {
            _weight = weight;
            _stateOfCharge = 50;
        }

        public Scooter(string description, string brand, int enginPower, double weight)
            : this(description, brand, enginPower, 25, weight) { }


        public int StateOfCharge
        {
            get { return _stateOfCharge; }
        }

        public double Weight
		{
			get { return _weight; }		
		}

	}
}
