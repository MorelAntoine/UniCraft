using UniCraft.Character.Mechanism.System.Motion.Information;
using UniCraft.Character.Mechanism.System.Motion.StateMachine.State;
using UnityEngine;

namespace UniCraft.Character.Mechanism.System.Motion.StateMachine
{
	/// <summary>
	/// Brain class to control the motion state machine
	/// </summary>
	[global::System.Serializable]
	public class MotionStateMachine
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		[SerializeField] private AMotionState _currentMotionState;
		[SerializeField] private AMotionState _previousMotionState;
		[SerializeField] private AMotionState _entryMotionState;
		public bool ShouldDisplayDebugTransitionLog;
		private EMotionType _motionType;

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		/////////////////////////
		////////// API //////////

		/// <summary>
		/// Initialize the motion state machine
		/// </summary>
		public void Initialize(ACharacterSystem cs)
		{
			if (_entryMotionState == null)
				Debug.LogError("[MSM] There is no entry motion state to the motion state machine!");
			else
				_currentMotionState = _entryMotionState;
			_motionType = cs.GetType().IsSubclassOf(typeof(ACharacterSystem3D)) ? EMotionType.Motion3D : EMotionType.Motion2D;
		}

		/// <summary>
		/// Execute the movement of the current motion state
		/// </summary>
		public void Execute(ACharacterSystem cs, MotionInformation mi)
		{
			if (_currentMotionState != null)
				_currentMotionState.Move(cs, mi, _motionType);
		}

		/// <summary>
		/// Update the current motion state
		/// </summary>
		public void Update(ACharacterSystem cs, MotionInformation mi)
		{
			if (_currentMotionState == null)
				return;
			
			var nextMotionState = _currentMotionState.AttemptToGetNextMotionState(cs, mi, _motionType);
			if (nextMotionState != null)
			{
				_previousMotionState = _currentMotionState;
				_currentMotionState = nextMotionState;
				if (ShouldDisplayDebugTransitionLog)
					DisplayDebugTransitionLog();
			}
		}
		
		///////////////////////////
		////////// Debug //////////

		private void DisplayDebugTransitionLog()
		{
			Debug.Log("[MSM] " + _previousMotionState.GetType().Name + " -> " + _currentMotionState.GetType().Name);
		}
	}
}
