using UniCraft.Character.MotionStateMachine;
using UniCraft.Character.MotionStateMachine.Condition;
using UniCraft.Character.System;
using UnityEngine;

namespace UniCraft.Examples.Character.MotionStateMachine.Condition.Velocity.Positive
{
	[CreateAssetMenu(menuName = "UniCraft/Character/Condition/Velocity/Positive/IsMoving")]
	public class IsMovingCondition : AMotionCondition
	{
		protected override bool IsComplete2D(ACharacterSystem2D cs2D, MotionInformation mi)
		{
			return (cs2D.Rigidbody2D.velocity.x != 0f || cs2D.Rigidbody2D.velocity.y != 0f);
		}

		protected override bool IsComplete3D(ACharacterSystem3D cs3D, MotionInformation mi)
		{
			return (cs3D.Rigidbody.velocity.x != 0f || cs3D.Rigidbody.velocity.y != 0f || cs3D.Rigidbody.velocity.z != 0f);
		}
	}
}
