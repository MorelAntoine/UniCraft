using UniCraft.Gamepad.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.Condition
{
	public abstract class AMotionCondition : ScriptableObject
	{
		public abstract bool IsComplete(CharacterSystem cs, GamepadInputInformation inputInfos);

		public abstract bool IsComplete2D(CharacterSystem2D cs2D, GamepadInputInformation inputInfos);
	}
}
