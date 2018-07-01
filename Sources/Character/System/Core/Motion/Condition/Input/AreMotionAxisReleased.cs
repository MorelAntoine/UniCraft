using UniCraft.Gamepad.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.Condition.Input
{
	[CreateAssetMenu(menuName = "UniCraft/Character/Condition/AreMotionAxisReleased")]
	public class AreMotionAxisReleased : AMotionCondition
	{
		////////// AMotionCondition callbacks //////////

		public override bool IsComplete(CharacterSystem cs, GamepadInputInformation inputInfos)
		{
			return (ConditionLogic(inputInfos));
		}

		public override bool IsComplete2D(CharacterSystem2D cs2D, GamepadInputInformation inputInfos)
		{
			return (ConditionLogic(inputInfos));
		}
		
		////////// Services //////////

		private static bool ConditionLogic(GamepadInputInformation inputInfos)
		{
			return (inputInfos.MotionHorizontalAxisValue == 0f && inputInfos.MotionVerticalAxisValue == 0f);
		}
	}
}
