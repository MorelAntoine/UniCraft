using UnityEngine;

namespace UniCraft.Gamepad.Core
{
	[System.Serializable]
	public class GamepadInputInformation
	{
		////////////////////////////////
		////////// Attributes //////////
		
		////////// Axis values //////////

		[Header("Axis values")]
		[SerializeField] private float _motionHorizontalAxisValue;
		[SerializeField] private float _motionVerticalAxisValue;
		
		////////// Button values //////////

		[Header("Button values")]
		[SerializeField] private bool _jumpButtonValue;
		
		////////////////////////////////
		////////// Properties //////////
		
		////////// Axis values //////////

		public float MotionHorizontalAxisValue
		{
			get { return _motionHorizontalAxisValue; }
			set { _motionHorizontalAxisValue = value; }
		}

		public float MotionVerticalAxisValue
		{
			get { return _motionVerticalAxisValue; }
			set { _motionVerticalAxisValue = value; }
		}

		////////// Button values //////////

		public bool JumpButtonValue
		{
			get { return _jumpButtonValue; }
			set { _jumpButtonValue = value; }
		}
	}
}
