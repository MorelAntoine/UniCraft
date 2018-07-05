using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.State.Locomotion
{
	[CreateAssetMenu(menuName = "UniCraft/Character/State/Locomotion/Ascent")]
	public class Ascent : AMotionState
	{
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public override void Move(CharacterSystem cs, GamepadInputInformation inputInformation)
		{}

		public override void Move2D(CharacterSystem2D cs2D, GamepadInputInformation inputInformation)
		{}
	}
}
