using UniCraft.Gamepad.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.Condition.Input
{
	[CreateAssetMenu(menuName = "UniCraft/Character/Condition/IsJumpButtonPressed")]
	public class IsJumpButtonPressed : AMotionCondition
	{
		public override bool IsComplete(CharacterSystem cs, GamepadInputInformation inputInfos)
		{
			return (inputInfos.JumpButtonValue);
		}

		public override bool IsComplete2D(CharacterSystem2D cs2D, GamepadInputInformation inputInfos)
		{
			return (inputInfos.JumpButtonValue);
		}
	}
}
