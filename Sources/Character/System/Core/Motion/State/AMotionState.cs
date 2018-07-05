using UniCraft.Character.System.Core.Motion.Transition;
using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.State
{
	public abstract class AMotionState : ScriptableObject
	{	
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		//////////////////////////////
		////////// Resource //////////

		private AMotionState _nextMotionState;
		
		/////////////////////////////
		////////// Setting //////////
		
		[Header("Setting")]
		[SerializeField] private MotionTransition[] _transitions;
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		/////////////////////////
		////////// API //////////
		
		public AMotionState AttemptToGetNextState(CharacterSystem cs, GamepadInputInformation inputInformation)
		{
			foreach (var t in _transitions)
			{
				_nextMotionState = t.GetNextState(cs, inputInformation);
				if (_nextMotionState != null)
					return (_nextMotionState);
			}
			return (null);
		}

		public AMotionState AttemptToGetNextState2D(CharacterSystem2D cs2D, GamepadInputInformation inputInformation)
		{
			foreach (var t in _transitions)
			{
				_nextMotionState = t.GetNextState2D(cs2D, inputInformation);
				if (_nextMotionState != null)
					return (_nextMotionState);
			}
			return (null);
		}
		
		//////////////////////////////
		////////// Callback //////////
		
		public abstract void Move(CharacterSystem cs, GamepadInputInformation inputInformation);
		public abstract void Move2D(CharacterSystem2D cs2D, GamepadInputInformation inputInformation);
	}
}
