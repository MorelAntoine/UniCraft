using UniCraft.Gamepad.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.State.Locomotion
{
	[CreateAssetMenu(menuName = "UniCraft/Character/State/Locomotion/Idle")]
	public class Idle : AMotionState
	{
		public override void Move(CharacterSystem cs, GamepadInputInformation inputInfos)
		{}

		public override void Move2D(CharacterSystem2D cs2D, GamepadInputInformation inputInfos)
		{}
	}
}
