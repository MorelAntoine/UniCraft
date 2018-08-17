using UniCraft.Character.Mechanism.System;
using UniCraft.Character.Mechanism.System.Motion.Information;
using UniCraft.Character.Mechanism.System.Motion.StateMachine.State;
using UnityEngine;

namespace UniCraft.Character.Kit.Motion.State.Locomotion
{
	[CreateAssetMenu(menuName = "CharacterKit/State/Locomotion/Idle")]
	public class IdleState : AMotionState
	{
		protected override void Move2D(ACharacterSystem2D cs, MotionInformation mi)
		{
		}

		protected override void Move3D(ACharacterSystem3D cs, MotionInformation mi)
		{
		}
	}
}
