using UniCraft.Character.System.Core.Motion.State;
using UniCraft.Character.System.Core.Profile;
using UniCraft.Gamepad.Core;
using UniCraft.Toolbox.Attribute;
using UnityEngine;

namespace UniCraft.Character.System.Core
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(AttributesProfile), typeof(InformationProfile))]
	public abstract class ACharacterSystem : MonoBehaviour
	{
		////////////////////////////////
		////////// Attributes //////////
		
		////////// Motion state machine //////////
		
		////////// Information

		[Header("M.S.M - Information")]
		[DisableInInspector, SerializeField] private AMotionState _currentState;
		[DisableInInspector, SerializeField] private AMotionState _previousState;
		
		////////// Settings

		[Header("M.S.M - Settings")]
		[SerializeField] private AMotionState _startingState;
		[SerializeField] private bool _useDebugger;
		
		////////// Profiles //////////

		private AttributesProfile _attributes;
		private InformationProfile _information;
		
		////////// Resources //////////
		
		private bool _is3DMode;
		
		////////////////////////////////
		////////// Properties //////////

		////////// Profiles //////////

		public AttributesProfile Attributes
		{
			get { return _attributes; }
		}

		public InformationProfile Information
		{
			get { return _information; }
		}
		
		/////////////////////////////
		////////// Methods //////////
		
		////////// Callbacks //////////
		
		////////// ACharacterSystem
		
		public void UpdateMotionStateMachine(GamepadInputInformation inputInfos)
		{
			if (_currentState == null)
				return;
			if (_is3DMode)
			{
				AttemptToChangeState(_currentState.AttemptToGetNextState(this as CharacterSystem, inputInfos));
				_currentState.Move(this as CharacterSystem, inputInfos);	
			}
			else
			{
				AttemptToChangeState(_currentState.AttemptToGetNextState2D(this as CharacterSystem2D, inputInfos));
				_currentState.Move2D(this as CharacterSystem2D, inputInfos);	
			}
		}
		
		////////// MonoBehaviour

		private void Awake()
		{
			InitializeMotionStateMachine();
			LoadProfiles();
			Initialize();
		}
		
		////////// Services //////////
		
		////////// Debug

		private void DisplayDebugTransition()
		{
			Debug.Log("[M.S.M - Debug] " + _previousState.GetType().Name + " --> " + _currentState.GetType().Name);
		}
		
		////////// Initialization
		
		protected abstract void Initialize();
		
		private void InitializeMotionStateMachine()
		{
			_currentState = _startingState;
			if (_currentState == null)
				Debug.LogError("[Character System] Starting state is empty!");
			_is3DMode = GetType() == typeof(CharacterSystem);
		}

		private void LoadProfiles()
		{
			_attributes = GetComponent<AttributesProfile>();
			_information = GetComponent<InformationProfile>();
		}
		
		////////// Motion state
		
		private void AttemptToChangeState(AMotionState nextMotionState)
		{
			if (nextMotionState == null)
				return;
			_previousState = _currentState;
			_currentState = nextMotionState;
			if (_useDebugger)
				DisplayDebugTransition();
		}
	}
}
