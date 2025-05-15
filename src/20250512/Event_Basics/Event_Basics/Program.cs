using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> messageAction = ShowMessage;
            messageAction("Hello world..");

            var shapeList = new List<Shape>
            {
                new Shape("Circle", int.MaxValue),
                new Shape("Rectangle", 4),
                new Shape("Hexagon", 6)
            };

            //make some subscriptions
            foreach (var shape in shapeList)
            {
                shape.ShapeIsDrawn += Shape_ShapeIsDrawn; 
            }

            foreach (var shape in shapeList)
            {
                shape.Draw();
            }

            //remove some subscriptions
            //foreach (var shape in shapeList)
            //{
            //    shape.ShapeIsDrawn -= ShowMessage;
            //}
        }

        private static void Shape_ShapeIsDrawn(object sender, EventArgs e)
        {
            var shape = sender as Shape;
            if(shape == null)
            {
                return;
            }

            Console.WriteLine("EVENT: " + shape.Description + " is drawn.");
        }

        static void ShowMessage(string messageToShow)
        {
            Console.WriteLine(messageToShow.ToUpper());
        }
    }
}
