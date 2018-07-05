using UnityEngine;

namespace UniCraft.Toolbox.Structure
{
	[System.Serializable]
	public struct Boundary
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		[SerializeField] private float _xMin;
		[SerializeField] private float _xMax;
		[SerializeField] private float _yMin;
		[SerializeField] private float _yMax;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////
		
		public float XMin
		{
			get { return _xMin; }
			set { _xMin = value; }
		}

		public float XMax
		{
			get { return _xMax; }
			set { _xMax = value; }
		}

		public float YMin
		{
			get { return _yMin; }
			set { _yMin = value; }
		}

		public float YMax
		{
			get { return _yMax; }
			set { _yMax = value; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		/////////////////////////////////
		////////// Constructor //////////
		
		public Boundary(float minX, float maxX, float minY, float maxY)
		{
			_xMin = minX;
			_xMax = maxX;
			_yMin = minY;
			_yMax = maxY;
		}

		////////////////////////////////
		////////// Management //////////
		
		public void SetBoundary(float minX, float maxX, float minY, float maxY)
		{
			SetXBoundary(minX, maxX);
			SetYBoundary(minY, maxY);
		}
		
		public void SetXBoundary(float minX, float maxX)
		{
			_xMin = minX;
			_xMax = maxX;
		}

		public void SetYBoundary(float minY, float maxY)
		{
			_yMin = minY;
			_yMax = maxY;
		}
		
		//////////////////////////////
		////////// Override //////////

		public override string ToString()
		{
			return ("Boundary: X [" + _xMin.ToString() + ", " + _xMax.ToString() + "] Y [" + _yMin.ToString()
			        + ", " + _yMax.ToString() + "]");
		}
	}
}
