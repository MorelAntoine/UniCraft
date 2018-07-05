using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.Condition
{
	public abstract class AMotionCondition : ScriptableObject
	{
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public abstract bool IsComplete(CharacterSystem cs, GamepadInputInformation inputInformation);
		public abstract bool IsComplete2D(CharacterSystem2D cs2D, GamepadInputInformation inputInformation);
	}
}
