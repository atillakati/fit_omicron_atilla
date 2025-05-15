using System;

namespace Event_Basics
{
    public class Shape
    {
		private string _description;
		private int _vertexCount;

		public event EventHandler ShapeIsDrawn;

        public Shape(string description, int vertices)
        {
			_description = description;
			_vertexCount = vertices;
        }

        public int VertexCount
		{
			get { return _vertexCount; }			
		}

		public string Description
		{
			get { return _description; }			
		}

		public void Draw()
		{
            Console.WriteLine($"Drawing the shape '{_description}'...");

			//fire the event if it is not null
			ShapeIsDrawn?.Invoke(this, new EventArgs()); //_description + " is drawn.");
        }

	}
}
