using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.Condition.Context
{
	[CreateAssetMenu(menuName = "UniCraft/Character/Condition/Context/IsFalling")]
	public class IsFalling : AMotionCondition
	{
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public override bool IsComplete(CharacterSystem cs, GamepadInputInformation inputInformation)
		{
			return (cs.Rigidbody.velocity.y < 0);
		}

		public override bool IsComplete2D(CharacterSystem2D cs2D, GamepadInputInformation inputInformation)
		{
			return (cs2D.Rigidbody2D.velocity.y < 0);
		}
	}
}
