using UniCraft.Toolbox.Attribute;
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
		[DisableInInspector, SerializeField] private float _motionHorizontalAxisValue;
		[DisableInInspector, SerializeField] private float _motionVerticalAxisValue;
		
		////////// Button values //////////

		[Header("Button values")]
		[DisableInInspector, SerializeField] private bool _jumpButtonValue;
		
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
