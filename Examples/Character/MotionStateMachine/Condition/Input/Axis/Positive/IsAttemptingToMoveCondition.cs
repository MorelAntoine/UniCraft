using UniCraft.Character.MotionStateMachine;
using UniCraft.Character.MotionStateMachine.Condition;
using UniCraft.Character.System;
using UnityEngine;

namespace UniCraft.Examples.Character.MotionStateMachine.Condition.Input.Axis.Positive
{
	[CreateAssetMenu(menuName = "UniCraft/Character/Condition/Input/Axis/Positive/IsAttemptingToMove")]
	public class IsAttemptingToMoveCondition : AMotionCondition
	{
		protected override bool IsComplete2D(ACharacterSystem2D cs2D, MotionInformation mi)
		{
			return (WrappedCondition(mi));
		}

		protected override bool IsComplete3D(ACharacterSystem3D cs3D, MotionInformation mi)
		{
			return (WrappedCondition(mi));
		}

		private bool WrappedCondition(MotionInformation mi)
		{
			return (mi.MovementDirection.x != 0f || mi.MovementDirection.y != 0f || mi.MovementDirection.z != 0f);
		}
	}
}
