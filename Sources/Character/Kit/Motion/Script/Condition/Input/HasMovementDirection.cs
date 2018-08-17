using UniCraft.Character.Mechanism.System;
using UniCraft.Character.Mechanism.System.Motion.Information;
using UniCraft.Character.Mechanism.System.Motion.StateMachine.Condition;
using UnityEngine;

namespace UniCraft.Character.Kit.Motion.Condition.Input
{
	[CreateAssetMenu(menuName = "CharacterKit/Condition/Input/HasMovementDirection")]
	public class HasMovementDirection : AMotionCondition
	{
		protected override bool IsComplete2D(ACharacterSystem2D cs, MotionInformation mi)
		{
			return (mi.Input.MovementDirection.x != 0f || mi.Input.MovementDirection.y != 0f || mi.Input.MovementDirection.z != 0f);
		}

		protected override bool IsComplete3D(ACharacterSystem3D cs, MotionInformation mi)
		{
			return (mi.Input.MovementDirection.x != 0f || mi.Input.MovementDirection.y != 0f || mi.Input.MovementDirection.z != 0f);
		}
	}
}
