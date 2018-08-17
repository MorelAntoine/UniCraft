using System.Linq;
using UniCraft.Character.Mechanism.System.Motion.Information;
using UniCraft.Character.Mechanism.System.Motion.StateMachine.Condition;
using UniCraft.Character.Mechanism.System.Motion.StateMachine.State;
using UnityEngine;

namespace UniCraft.Character.Mechanism.System.Motion.StateMachine.Transition
{
	/// <inheritdoc/>
	/// <summary>
	/// Class to create a motion transition for the motion state machine
	/// </summary>
	[CreateAssetMenu(menuName = "UniCraft/Character/MotionTransition")]
	public class MotionTransition : ScriptableObject
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		[SerializeField] private AMotionCondition[] _motionConditions;
		[SerializeField] private AMotionState _motionStateOnSuccess;
		[SerializeField] private AMotionState _motionStateOnFailure;

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		/////////////////////////
		////////// API //////////

		/// <summary>
		/// Return either the motionStateOnSuccess or the motionStateOnFailure depending on the conditions result
		/// </summary>
		public AMotionState GetResultingMotionState(ACharacterSystem cs, MotionInformation mi, EMotionType motionType)
		{
			return (AreConditionsMet(cs, mi, motionType) ? _motionStateOnSuccess : _motionStateOnFailure);
		}
		
		/////////////////////////////
		////////// Service //////////
		
		/// <summary>
		/// Check if all the conditions are met
		/// </summary>
		private bool AreConditionsMet(ACharacterSystem cs, MotionInformation mi, EMotionType motionType)
		{
			return (_motionConditions.All(mc => mc.IsComplete(cs, mi, motionType)));
		}
		
	}
}
