using UnityEngine;

namespace UniCraft.Toolbox.Component.GamepadSystem.Core
{
	[System.Serializable]
	public sealed class GamepadConfiguration
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		///////////////////////////////
		////////// Axis name //////////

		[Header("Axis name")]
		[SerializeField] private string _motionHorizontalAxisName = "Horizontal";
		[SerializeField] private string _motionVerticalAxisName = "Vertical";
		
		/////////////////////////////////
		////////// Button name //////////

		[Header("Button name")]
		[SerializeField] private string _crouchButtonName = "Crouch";
		[SerializeField] private string _jumpButtonName = "Jump";
		[SerializeField] private string _runButtonName = "Run";
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////
		
		///////////////////////////////
		////////// Axis name //////////

		public string MotionHorizontalAxisName
		{
			get { return _motionHorizontalAxisName; }
		}

		public string MotionVerticalAxisName
		{
			get { return _motionVerticalAxisName; }
		}

		/////////////////////////////////
		////////// Button name //////////

		public string CrouchButtonName
		{
			get { return _crouchButtonName; }
		}

		public string JumpButtonName
		{
			get { return _jumpButtonName; }
		}
		
		public string RunButtonName
		{
			get { return _runButtonName; }
		}
	}
}
