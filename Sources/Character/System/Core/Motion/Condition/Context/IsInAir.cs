using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.Condition.Context
{
	[CreateAssetMenu(menuName = "UniCraft/Character/Condition/Context/IsInAir")]
	public class IsInAir : AMotionCondition
	{
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public override bool IsComplete(CharacterSystem cs, GamepadInputInformation inputInformation)
		{
			return (cs.Context.IsGrounded() == false);
		}

		public override bool IsComplete2D(CharacterSystem2D cs2D, GamepadInputInformation inputInformation)
		{
			return (cs2D.Context2D.IsGrounded() == false);
		}
	}
}
