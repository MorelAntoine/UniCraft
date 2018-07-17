using UniCraft.Character.MotionStateMachine;
using UnityEngine;

namespace UniCraft.Character.Behaviour
{
	public abstract class ACharacterBehaviour : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		///////////////////////////////
		////////// Component //////////

		[SerializeField] private MotionStateMachine.MotionStateMachine _motionStateMachine;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		/////////////////////////////////
		////////// Information //////////
		
		////////// Motion State Machine //////////
		
		protected MotionInformation MotionInformation
		{
			get { return (_motionStateMachine.MotionInformation); }
		}
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////

		protected abstract void UpdateMotionInformation();
	}
}
