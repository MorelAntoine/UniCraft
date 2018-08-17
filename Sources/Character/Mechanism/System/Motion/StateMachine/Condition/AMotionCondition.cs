using System;
using UniCraft.Character.Mechanism.System.Motion.Information;
using UnityEngine;

namespace UniCraft.Character.Mechanism.System.Motion.StateMachine.Condition
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to create a motion condition for the motion state machine
	/// </summary>
	public abstract class AMotionCondition : ScriptableObject
	{
		////////////////////////////
		////////// Method //////////
		////////////////////////////

		/////////////////////////
		////////// API //////////
		
		/// <summary>
		/// Verify if the condition is complete
		/// </summary>
		public bool IsComplete(ACharacterSystem cs, MotionInformation mi, EMotionType motionType)
		{
			switch (motionType)
			{
				case EMotionType.Motion2D:
					return (IsComplete2D(cs as ACharacterSystem2D, mi));
				case EMotionType.Motion3D:
					return (IsComplete3D(cs as ACharacterSystem3D, mi));
				default:
					throw new ArgumentOutOfRangeException("motionType", motionType, null);
			}
		}

		//////////////////////////////
		////////// Callback //////////
		
		/// <summary>
		/// Callback to verify if the condition is complete for the 2D space
		/// </summary>
		protected abstract bool IsComplete2D(ACharacterSystem2D cs, MotionInformation mi);

		/// <summary>
		/// Callback to verify if the condition is complete for the 3D space
		/// </summary>
		protected abstract bool IsComplete3D(ACharacterSystem3D cs, MotionInformation mi);

	}
}
