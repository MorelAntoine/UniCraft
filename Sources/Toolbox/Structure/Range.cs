using UnityEngine;

namespace UniCraft.Toolbox.Structure
{
	[System.Serializable]
	public struct Range
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		[SerializeField] private float _min;
		[SerializeField] private float _max;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////
		
		public float Max
		{
			get { return _max; }
			set { _max = value; }
		}

		public float Min
		{
			get { return _min; }
			set { _min = value; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		/////////////////////////////////
		////////// Constructor //////////
		
		public Range(float minimum, float maximum)
		{
			_max = maximum;
			_min = minimum;
		}

		////////////////////////////////
		////////// Management //////////
		
		public void SetRange(float minimum, float maximum)
		{
			_max = maximum;
			_min = minimum;
		}
		
		//////////////////////////////
		////////// Override //////////

		public override string ToString()
		{
			return ("Range [" + _min.ToString() + ", " + _max.ToString() + "]");
		}
	}
}
