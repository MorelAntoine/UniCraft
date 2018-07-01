using UnityEngine;

namespace UniCraft.Character.Behaviour.Controller
{
	[AddComponentMenu("UniCraft/Character/Behaviour/Controller/PlayerCharacterController")]
	public class PlayerCharacterController : ACharacterBehaviour 
	{
		////////////////////////////////
		////////// Attributes //////////
		
		////////// Settings //////////

		[Header("Settings")]
		public bool UseRawInput;
		
		/////////////////////////////
		////////// Methods //////////
		
		protected override void Initialize()
		{}

		protected override void UpdateInputInfos()
		{
			if (UseRawInput)
			{
				InputInfos.MotionHorizontalAxisValue = Input.GetAxisRaw(GamepadConfiguration.MotionHorizontalAxisName);
				InputInfos.MotionVerticalAxisValue = Input.GetAxisRaw(GamepadConfiguration.MotionVerticalAxisName);
			}
			else
			{
				InputInfos.MotionHorizontalAxisValue = Input.GetAxis(GamepadConfiguration.MotionHorizontalAxisName);
				InputInfos.MotionVerticalAxisValue = Input.GetAxis(GamepadConfiguration.MotionVerticalAxisName);	
			}
			InputInfos.JumpButtonValue = Input.GetButtonDown(GamepadConfiguration.JumpButtonName);
		}
	}
}
