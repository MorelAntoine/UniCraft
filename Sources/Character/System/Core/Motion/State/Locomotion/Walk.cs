using UniCraft.Gamepad.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.State.Locomotion
{
	[CreateAssetMenu(menuName = "UniCraft/Character/State/Locomotion/Walk")]
	public class Walk : AMotionState
	{
		////////////////////////////////
		////////// Attributes //////////

		private Vector3 _movement = Vector3.zero;
		
		/////////////////////////////
		////////// Methods //////////
		
		public override void Move(CharacterSystem cs, GamepadInputInformation inputInfos)
		{
			cs.transform.Rotate(0f, inputInfos.MotionHorizontalAxisValue * cs.Attributes.TurnSpeed * Time.deltaTime, 0f);
			cs.transform.Translate(0f, 0f, inputInfos.MotionVerticalAxisValue * cs.Attributes.WalkSpeed * Time.deltaTime, Space.Self);
		}

		public override void Move2D(CharacterSystem2D cs2D, GamepadInputInformation inputInfos)
		{}
	}
}
