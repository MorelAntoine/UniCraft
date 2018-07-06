using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.Condition.Input
{
	[CreateAssetMenu(menuName = "UniCraft/Character/Condition/Input/IsRunButtonReleased")]
	public class IsRunButtonReleased : AMotionCondition
	{
		////////////////////////////
		////////// Method //////////
		////////////////////////////

		///////////////////////////////////////////////
		////////// AMotionCondition callback //////////

		public override bool IsComplete(CharacterSystem cs, GamepadInputInformation inputInformation)
		{
			return (inputInformation.RunButtonValue == false);
		}

		public override bool IsComplete2D(CharacterSystem2D cs2D, GamepadInputInformation inputInformation)
		{
			return (inputInformation.RunButtonValue == false);
		}
	}
}
