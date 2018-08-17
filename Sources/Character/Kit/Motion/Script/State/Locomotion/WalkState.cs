using UniCraft.Character.Mechanism.System;
using UniCraft.Character.Mechanism.System.Motion.Information;
using UniCraft.Character.Mechanism.System.Motion.StateMachine.State;
using UnityEngine;

namespace UniCraft.Character.Kit.Motion.State.Locomotion
{
	[CreateAssetMenu(menuName = "CharacterKit/State/Locomotion/Walk")]
	public class WalkState : AMotionState
	{
		protected override void Move2D(ACharacterSystem2D cs, MotionInformation mi)
		{
		}

		protected override void Move3D(ACharacterSystem3D cs, MotionInformation mi)
		{
			var correctAmountOfAngularSpeed = cs.LocomotionProfile.LerpAngularSpeed(Mathf.Abs(mi.Input.MovementDirection.z));

			if (mi.Configuration.ShouldAdaptToNavMesh)
				mi.Input.MovementDirection = cs.transform.InverseTransformDirection(mi.Input.MovementDirection);
			cs.transform.Rotate(0f, mi.Input.MovementDirection.x * correctAmountOfAngularSpeed * Time.fixedDeltaTime, 0f, Space.Self);
			cs.transform.Translate(0f, 0f, mi.Input.MovementDirection.z * cs.LocomotionProfile.WalkSpeed * Time.fixedDeltaTime, Space.Self);
		}
	}
}
