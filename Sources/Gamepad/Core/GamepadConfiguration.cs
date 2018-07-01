using UnityEngine;

namespace UniCraft.Gamepad.Core
{
	[System.Serializable]
	public class GamepadConfiguration
	{
		////////////////////////////////
		////////// Attributes //////////
		
		////////// Axis names //////////

		[Header("Axis names")]
		[SerializeField] private string _motionHorizontalAxisName = "Horizontal";
		[SerializeField] private string _motionVerticalAxisName = "Vertical";
		
		////////// Button names //////////

		[Header("Button names")]
		[SerializeField] private string _jumpButtonName = "Jump";
		
		////////////////////////////////
		////////// Properties //////////
		
		////////// Axis names //////////

		public string MotionHorizontalAxisName
		{
			get { return _motionHorizontalAxisName; }
		}

		public string MotionVerticalAxisName
		{
			get { return _motionVerticalAxisName; }
		}

		////////// Button names //////////

		public string JumpButtonName
		{
			get { return _jumpButtonName; }
		}
	}
}
