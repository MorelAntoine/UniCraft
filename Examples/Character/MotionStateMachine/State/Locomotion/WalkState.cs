using UniCraft.Character.System;
using UnityEngine;

namespace UniCraft.Character.MotionStateMachine.State.Locomotion
{
	[CreateAssetMenu(menuName = "UniCraft/Character/State/Locomotion/Walk")]
	public class WalkState : AMotionState
	{			
		protected override void Run2D(ACharacterSystem2D cs2D, MotionInformation mi)
		{
			cs2D.Rigidbody2D.velocity = mi.MovementDirection * cs2D.LocomotionAttribute.WalkSpeed * Time.fixedDeltaTime;
		}

		protected override void Run3D(ACharacterSystem3D cs3D, MotionInformation mi)
		{
			cs3D.transform.Rotate(0f, mi.MovementDirection.x * cs3D.LocomotionAttribute.TurnSpeed * Time.fixedDeltaTime, 0f);
			cs3D.transform.Translate(0f, 0f, mi.MovementDirection.z * cs3D.LocomotionAttribute.WalkSpeed* Time.fixedDeltaTime, Space.Self);
		}
	}
}
