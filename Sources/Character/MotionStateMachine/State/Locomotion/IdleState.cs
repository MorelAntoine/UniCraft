using UniCraft.Character.System;
using UnityEngine;

namespace UniCraft.Character.MotionStateMachine.State.Locomotion
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
