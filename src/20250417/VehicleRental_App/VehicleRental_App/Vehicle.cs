using System;

namespace VehicleRental_App
{
    public class Vehicle
    {
        private string _description;
        private string _brand;
        private int _currentSpeed;
        private int _maxSpeed;
        private int _enginePower;
        

        //user spezific constructor
        public Vehicle(string description, string brand, int enginePower, int maxSpeed)
        {
            _brand = brand;
            _enginePower = enginePower;
            _description = description;
            _maxSpeed = maxSpeed;

            _currentSpeed = 0;
        }


        public int CurrentSpeed
        {
            get
            {
                return _currentSpeed;
            }            
        }

        public string Brand 
        { 
            get { return _brand; }
        }

        public int EnginePower 
        { 
            get { return _enginePower; }
        }

        public int MaxSpeed 
        { 
            get { return _maxSpeed; }
        }

        public string Description 
        { 
            get { return _description; }
        }


        public bool SpeedUp(int delta)
        {
            if (_currentSpeed + delta <= _maxSpeed)
            {
                _currentSpeed += delta;
                return true;
            }

            return false;
        }

        public string GetInfoString()
        {
            string info = $"{_brand} - {_description}";
            info += $"\nPower: {_enginePower} PS [{_currentSpeed} / {_maxSpeed} km/h]";

            return info;
        }
    }
}