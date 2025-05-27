using System;

namespace Class_Example_2
{
    public class Vehicle
    {
        private string _description;
        private ConsoleColor _color;
        private int _currentSpeed;
        private int _maxSpeed;


        //constructor ==> to create a valid object => Semantic consistency

        //std. constructor
        //public Vehicle()
        //{

        //}        

        //user spezific constructor
        public Vehicle(string description, int maxSpeed)
        {
            _color = ConsoleColor.White;
            _currentSpeed = 0;
            _description = description;
            _maxSpeed = maxSpeed;            
        }

        public Vehicle(string description, int maxSpeed, ConsoleColor color)
        {
            _color = color;
            _currentSpeed = 0;
            _description = description;
            _maxSpeed = maxSpeed;
        }        

        public int CurrentSpeed
        {
            get
            {
                return _currentSpeed;
            }            
        }        

        public ConsoleColor Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (CheckNewColorValue(value))
                {
                    _color = value;
                }
            }
        }

        private bool CheckNewColorValue(ConsoleColor newColor)
        {
            return newColor != ConsoleColor.Black;
        }

        public void SpeedUp(int delta)
        {
            if ((_currentSpeed + delta) <= _maxSpeed)
            {
                _currentSpeed += delta;
            }
        }

        public void Display()
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = _color;

            Console.WriteLine($"{_description} - [{_currentSpeed} / {_maxSpeed} km/h]");
        }
    }
}