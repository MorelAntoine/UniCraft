using UniCraft.Toolbox.Attribute;
using UnityEngine;

namespace UniCraft.Toolbox.Component.GamepadSystem.Core
{
	[System.Serializable]
	public sealed class GamepadInputInformation
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		////////////////////////////////
		////////// Axis value //////////

		[Header("Axis value")]
		[DisableInInspector, SerializeField] private float _motionHorizontalAxisValue;
		[DisableInInspector, SerializeField] private float _motionVerticalAxisValue;
		
		//////////////////////////////////
		////////// Button value //////////

		[Header("Button value")]
		[DisableInInspector, SerializeField] private bool _crouchButtonValue;
		[DisableInInspector, SerializeField] private bool _jumpButtonValue;
		[DisableInInspector, SerializeField] private bool _runButtonValue;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////
		
		////////////////////////////////
		////////// Axis value //////////

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

		//////////////////////////////////
		////////// Button value //////////

		public bool CrouchButtonValue
		{
			get { return _crouchButtonValue; }
			set { _crouchButtonValue = value; }
		}

		public bool JumpButtonValue
		{
			get { return _jumpButtonValue; }
			set { _jumpButtonValue = value; }
		}

		public bool RunButtonValue
		{
			get { return _runButtonValue; }
			set { _runButtonValue = value; }
		}
	}
}
