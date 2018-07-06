using UniCraft.Character.System.Core.Motion.State;
using UniCraft.Character.System.Core.Profile;
using UniCraft.Toolbox.Attribute;
using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core
{
	[DisallowMultipleComponent]
	public abstract class ACharacterSystem : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		/////////////////////////////////
		////////// Information //////////
		
		[Header("Information")]
		[DisableInInspector, SerializeField] private AMotionState _currentState;
		[DisableInInspector, SerializeField] private AMotionState _previousState;

		/////////////////////////////
		////////// Profile //////////
		
		[Header("Profile")]
		[SerializeField] private AttributesProfile _attributes;
		[SerializeField] private InformationProfile _information;
		
		//////////////////////////////
		////////// Resource //////////
		
		private bool _is3DMode;
		
		/////////////////////////////
		////////// Setting //////////
		
		[Header("Setting")]
		[SerializeField] private AMotionState _startingState;
		
		/////////////////////////////////////
		////////// Warning message //////////

		private const string NoStartingStateMessage = "There is no starting state on the character system!";
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		/////////////////////////////////
		////////// Information //////////

		public AMotionState CurrentState
		{
			get { return _currentState; }
		}

		public AMotionState PreviousState
		{
			get { return _previousState; }
		}

		/////////////////////////////
		////////// Profile //////////

		public AttributesProfile Attributes
		{
			get { return _attributes; }
		}

		public InformationProfile Information
		{
			get { return _information; }
		}
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		//////////////////////////////////////////
		////////// Motion state machine //////////
		
		////////// API //////////
		
		public void UpdateMotionStateMachine(GamepadInputInformation inputInformation)
		{
			if (_currentState == null)
				return;
			if (_is3DMode)
			{
				AttemptToChangeState(_currentState.AttemptToGetNextState(this as CharacterSystem, inputInformation));
				_currentState.Move(this as CharacterSystem, inputInformation);	
			}
			else
			{
				AttemptToChangeState(_currentState.AttemptToGetNextState2D(this as CharacterSystem2D, inputInformation));
				_currentState.Move2D(this as CharacterSystem2D, inputInformation);	
			}
		}
		
		////////// Callback //////////
		
		protected abstract void Initialize();
		
		////////// Service //////////
		
		private void AttemptToChangeState(AMotionState nextMotionState)
		{
			if (nextMotionState == null)
				return;
			_previousState = _currentState;
			_currentState = nextMotionState;
		}
		
		private void InitializeMotionStateMachine()
		{
			_currentState = _startingState;
			if (_currentState == null)
				Debug.LogError(NoStartingStateMessage);
			_is3DMode = GetType() == typeof(CharacterSystem);
		}
		
		////////////////////////////////////////////
		////////// MonoBehaviour callback //////////
		
		private void Awake()
		{
			InitializeMotionStateMachine();
			Initialize();
		}
	}
}
