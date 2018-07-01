using UniCraft.Character.System.Core.Motion.Transition;
using UniCraft.Gamepad.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.State
{
	public abstract class AMotionState : ScriptableObject
	{	
		////////////////////////////////
		////////// Attributes //////////

		////////// Resources //////////

		private AMotionState _nextMotionState;
		
		////////// Settings //////////
		
		[Header("Settings")]
		[SerializeField] private MotionTransition[] _transitions;
		
		/////////////////////////////
		////////// Methods //////////

		public AMotionState AttemptToGetNextState(CharacterSystem cs, GamepadInputInformation inputInfos)
		{
			foreach (var t in _transitions)
			{
				_nextMotionState = t.GetNextState(cs, inputInfos);
				if (_nextMotionState != null)
					return (_nextMotionState);
			}
			return (null);
		}

		public AMotionState AttemptToGetNextState2D(CharacterSystem2D cs2D, GamepadInputInformation inputInfos)
		{
			foreach (var t in _transitions)
			{
				_nextMotionState = t.GetNextState2D(cs2D, inputInfos);
				if (_nextMotionState != null)
					return (_nextMotionState);
			}
			return (null);
		}
		
		public abstract void Move(CharacterSystem cs, GamepadInputInformation inputInfos);

		public abstract void Move2D(CharacterSystem2D cs2D, GamepadInputInformation inputInfos);
	}
}
