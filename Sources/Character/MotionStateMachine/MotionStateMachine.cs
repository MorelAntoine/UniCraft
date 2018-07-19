using UniCraft.Attribute;
using UniCraft.Character.MotionStateMachine.State;
using UniCraft.Character.System;
using UnityEngine;

namespace UniCraft.Character.MotionStateMachine
{
    /// <inheritdoc/>
    /// <summary>
    /// Component class used to run the motion state machine mechanism
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ACharacterSystem))]
    public class MotionStateMachine : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        ///////////////////////////////
        ////////// Component //////////

        private ACharacterSystem _characterSystem;
        
        //////////////////////////////////////
        ////////// Compute Resource //////////

        private AMotionState _nextState;
        
        /////////////////////////////////
        ////////// Information //////////
        
        [CustomHeader("Information")]
        [SerializeField] private MotionInformation _motionInformation;
        [SerializeField, DisableInInspector(1)] private AMotionState _currentState;
        [SerializeField, DisableInInspector(1)] private AMotionState _previousState;
        
        /////////////////////////////
        ////////// Setting //////////

        [CustomHeader("Setting")]
        [SerializeField, IndentLevel(1)] private AMotionState _entryState;
        [SerializeField, IndentLevel(1)] private bool _useDebugLog;
        
        /////////////////////////////////////
        ////////// Warning Message //////////

        private const string NoEntryState = "[MotionStateMachine] There is no Entry State!";
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        public MotionInformation MotionInformation
        {
            get { return _motionInformation; }
        }
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        ////////////////////////////////////////////
        ////////// MonoBehaviour Callback //////////

        private void Awake()
        {
            _characterSystem = GetComponent<ACharacterSystem>();
            Setup();
        }

        private void FixedUpdate()
        {
            if (_currentState != null)
                RunCurrentState();
        }

        private void Update()
        {
            if (_currentState != null)
                AttemptToTransit();
        }
        
        ////////////////////////////////////////////////////
        ////////// Motion State Machine Mechanism //////////
        
        /// <summary>
        /// Attempts to transit to the next current state state
        /// </summary>
        private void AttemptToTransit()
        {
            _nextState = _currentState.AttemptToGetNextMotionState(_characterSystem, _motionInformation);
            if (_nextState == null)
                return;
            _previousState = _currentState;
            _currentState = _nextState;
            if (_useDebugLog)
                DisplayDebugLog();
        }

        /// <summary>
        /// Display the debug log on the console
        /// </summary>
        private void DisplayDebugLog()
        {
            Debug.Log("[MotionStateMachine] " + _previousState.GetType().Name + " -> " + _currentState.GetType().Name);
        }

        /// <summary>
        /// Runs the current state action
        /// </summary>
        private void RunCurrentState()
        {
            _currentState.Run(_characterSystem, _motionInformation);
        }

        /// <summary>
        /// Setup the motion state machine
        /// </summary>
        private void Setup()
        {
            if (_entryState != null)
                _currentState = _entryState;
            else
                Debug.LogError(NoEntryState);
            _motionInformation.Use3DMode = _characterSystem.GetType().IsSubclassOf(typeof(ACharacterSystem3D));
        }
    }
}
