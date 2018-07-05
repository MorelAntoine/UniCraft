using UnityEngine;

namespace UniCraft.Character.Behaviour.Controller
{
	[AddComponentMenu("UniCraft/Character/Behaviour/Controller/PlayerCharacterController")]
	public class PlayerCharacterController : ACharacterBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		///////////////////////////////
		////////// Setting //////////

		[Header("Setting")]
		[SerializeField] private bool _handleVerticalInput;
		[SerializeField] private bool _useRawAxisInput;
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		/////////////////////////////////////////////////
		////////// ACharacterBehaviour callback /////////
		
		protected override void Initialize()
		{}

		protected override void UpdateInputInformation()
		{
			if (_useRawAxisInput)
				HandleRawAxis();
			else
				HandleAxis();
			HandleButtons();
		}
		
		////////////////////////////
		////////// Service /////////

		private void HandleAxis()
		{
			InputInformation.MotionHorizontalAxisValue = Input.GetAxis(GamepadConfiguration.MotionHorizontalAxisName);
			if (_handleVerticalInput)
				InputInformation.MotionVerticalAxisValue = Input.GetAxis(GamepadConfiguration.MotionVerticalAxisName);
		}

		private void HandleButtons()
		{
			InputInformation.JumpButtonValue = Input.GetButtonDown(GamepadConfiguration.JumpButtonName);
			InputInformation.CrouchButtonValue = Input.GetButton(GamepadConfiguration.CrouchButtonName);
		}
		
		private void HandleRawAxis()
		{
			InputInformation.MotionHorizontalAxisValue = Input.GetAxisRaw(GamepadConfiguration.MotionHorizontalAxisName);
			if (_handleVerticalInput)
				InputInformation.MotionVerticalAxisValue = Input.GetAxisRaw(GamepadConfiguration.MotionVerticalAxisName);
		}
	}
}
