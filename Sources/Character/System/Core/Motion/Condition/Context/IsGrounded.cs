using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.Condition.Context
{
	[CreateAssetMenu(menuName = "UniCraft/Character/Condition/Context/IsGrounded")]
	public class IsGrounded : AMotionCondition
	{
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public override bool IsComplete(CharacterSystem cs, GamepadInputInformation inputInformation)
		{
			return (cs.Context.IsGrounded());
		}

		public override bool IsComplete2D(CharacterSystem2D cs2D, GamepadInputInformation inputInformation)
		{
			return (cs2D.Context2D.IsGrounded());
		}
	}
}
