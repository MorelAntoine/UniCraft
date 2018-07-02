using UniCraft.Gamepad.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.State.Locomotion
{
	[CreateAssetMenu(menuName = "UniCraft/Character/State/Locomotion/Jump")]
	public class Jump : AMotionState
	{
		////////////////////////////////
		////////// Attributes //////////

		private Vector2 _force2D = Vector2.zero;
		
		/////////////////////////////
		////////// Methods //////////
		
		public override void Move(CharacterSystem cs, GamepadInputInformation inputInfos)
		{
			cs.Rigidbody.AddForce(0f, Mathf.Sqrt(-2f * Physics.gravity.y * cs.Attributes.JumpHeight), 0f, ForceMode.Impulse);
		}

		public override void Move2D(CharacterSystem2D cs2D, GamepadInputInformation inputInfos)
		{
			_force2D.Set(0f, Mathf.Sqrt(-2f * Physics2D.gravity.y * cs2D.Attributes.JumpHeight));
			cs2D.Rigidbody2D.AddForce(_force2D, ForceMode2D.Impulse);
		}
	}
}
