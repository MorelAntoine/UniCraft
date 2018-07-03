using UnityEngine;

namespace UniCraft.Character.Behaviour.Controller
{
	[AddComponentMenu("UniCraft/Character/Behaviour/Controller/PlayerCharacterController")]
	public class PlayerCharacterController : ACharacterBehaviour 
	{
		protected override void Initialize()
		{}

		protected override void UpdateInputInfos()
		{
			InputInfos.MotionHorizontalAxisValue = Input.GetAxis(GamepadConfiguration.MotionHorizontalAxisName);
			InputInfos.MotionVerticalAxisValue = Input.GetAxis(GamepadConfiguration.MotionVerticalAxisName);
			InputInfos.JumpButtonValue = Input.GetButtonDown(GamepadConfiguration.JumpButtonName);
		}
	}
}
