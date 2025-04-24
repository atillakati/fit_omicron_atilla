using System;

namespace VehicleRental_App
{
    public abstract class Vehicle
    {
        private string _description;
        private string _brand;
        private int _currentSpeed;
        private int _maxSpeed;
        private int _enginePower;

        private Radio _carMedia;


        //user spezific constructor
        public Vehicle(string description, string brand, int enginePower, int maxSpeed)
        {
            _brand = brand;
            _enginePower = enginePower;
            _description = description;
            _maxSpeed = maxSpeed;

            _currentSpeed = 0;
            _carMedia = new Radio();
        }

        public void ChangeMediaPower(bool isPowerOn)
        {
            if (isPowerOn)
            {
                _carMedia.ChangeState(PowerState.On);
            }
            else
            {
                _carMedia.ChangeState(PowerState.Off);
            }
        }

        public void MakeNoise()
        {
            _carMedia.Play();
        }

        public string CurrentStationName { get { return _carMedia.StationName; } }

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

        public abstract string GetInfoString();

        //public virtual string GetInfoString()
        //{
        //    string info = $"{_brand} - {_description}";
        //    info += $"\nPower: {_enginePower} PS [{_currentSpeed} / {_maxSpeed} km/h]";

        //    return info;
        //}
    }
}