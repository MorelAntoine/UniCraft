using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.Condition.Input
{
	[CreateAssetMenu(menuName = "UniCraft/Character/Condition/Input/AreMotionAxisReleased")]
	public class AreMotionAxisReleased : AMotionCondition
	{
		////////////////////////////
		////////// Method //////////
		////////////////////////////

		///////////////////////////////////////////////
		////////// AMotionCondition callback //////////

		public override bool IsComplete(CharacterSystem cs, GamepadInputInformation inputInformation)
		{
			return (inputInformation.MotionHorizontalAxisValue == 0f && inputInformation.MotionVerticalAxisValue == 0f);
		}

		public override bool IsComplete2D(CharacterSystem2D cs2D, GamepadInputInformation inputInformation)
		{
			return (inputInformation.MotionHorizontalAxisValue == 0f && inputInformation.MotionVerticalAxisValue == 0f);
		}
	}
}
