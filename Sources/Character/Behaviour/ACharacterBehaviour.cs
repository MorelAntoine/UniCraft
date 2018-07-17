using UniCraft.Character.MotionStateMachine;
using UnityEngine;

namespace UniCraft.Character.Behaviour
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to create a character behaviour
	/// </summary>
	[DisallowMultipleComponent]
	[RequireComponent(typeof(MotionStateMachine.MotionStateMachine))]
	public abstract class ACharacterBehaviour : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		private MotionStateMachine.MotionStateMachine _motionStateMachine;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////
		
		protected MotionInformation MotionInformation
		{
			get { return (_motionStateMachine.MotionInformation); }
		}
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////

		//////////////////////////////////////////////////
		////////// ACharacterBehaviour Callback //////////
		
		/// <summary>
		/// Initilizes the behaviour
		/// </summary>
		protected abstract void Initialize();
		
		/// <summary>
		/// Updates the motion information for the motion state machine
		/// </summary>
		protected abstract void UpdateMotionInformation();
		
		////////////////////////////////////////////
		////////// MonoBehaviour Callback //////////

		private void Awake()
		{
			_motionStateMachine = GetComponent<MotionStateMachine.MotionStateMachine>();
			Initialize();
		}

		private void Update()
		{
			UpdateMotionInformation();
		}
	}
}
