using System;
using UniCraft.Character.Mechanism.System.Motion.Information;
using UniCraft.Character.Mechanism.System.Motion.StateMachine.Transition;
using UnityEngine;

namespace UniCraft.Character.Mechanism.System.Motion.StateMachine.State
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to create a motion state for the motion state machine
	/// </summary>
	public abstract class AMotionState : ScriptableObject
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		[SerializeField] private MotionTransition[] _motionTransitions;

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		/////////////////////////
		////////// API //////////

		/// <summary>
		/// Attempt to get the next motion state base on the motion transition of the current motion state
		/// </summary>
		public AMotionState AttemptToGetNextMotionState(ACharacterSystem cs, MotionInformation mi, EMotionType motionType)
		{
			foreach (var mt in _motionTransitions)
			{
				var nextMotionState = mt.GetResultingMotionState(cs, mi, motionType);
				if (nextMotionState != null)
					return (nextMotionState);
			}
			return (null);
		}

		/// <summary>
		/// Execute the movemement of the motion state
		/// </summary>
		public void Move(ACharacterSystem cs, MotionInformation mi, EMotionType motionType)
		{
			switch (motionType)
			{
				case EMotionType.Motion2D:
					Move2D(cs as ACharacterSystem2D, mi);
					break;
				case EMotionType.Motion3D:
					Move3D(cs as ACharacterSystem3D, mi);
					break;
				default:
					throw new ArgumentOutOfRangeException("motionType", motionType, null);
			}
		}
		
		//////////////////////////////
		////////// Callback //////////

		/// <summary>
		/// Callback to execute the movemement of the motion state in 2D space
		/// </summary>
		protected abstract void Move2D(ACharacterSystem2D cs, MotionInformation mi);

		/// <summary>
		/// Callback to execute the movemement of the motion state in 3D space
		/// </summary>
		protected abstract void Move3D(ACharacterSystem3D cs, MotionInformation mi);

	}
}
