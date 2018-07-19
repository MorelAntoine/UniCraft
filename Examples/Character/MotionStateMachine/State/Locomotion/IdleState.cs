using UniCraft.Character.MotionStateMachine;
using UniCraft.Character.MotionStateMachine.State;
using UniCraft.Character.System;
using UnityEngine;

namespace UniCraft.Examples.Character.MotionStateMachine.State.Locomotion
{
	[CreateAssetMenu(menuName = "UniCraft/Character/State/Locomotion/Idle")]
	public class IdleState : AMotionState
	{
		protected override void Run2D(ACharacterSystem2D cs2D, MotionInformation mi)
		{}

		protected override void Run3D(ACharacterSystem3D cs3D, MotionInformation mi)
		{}
	}
}
