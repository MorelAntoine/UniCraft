using UniCraft.Attribute;
using UniCraft.Toolbox.PluggableFiniteStateMachine.State;
using UnityEngine;

namespace UniCraft.Toolbox.PluggableFiniteStateMachine
{
	/// <inheritdoc/>
	/// <summary>
	/// Class used to hold all the mechanism of the pluggable finite state machine
	/// </summary>
	public class PluggableFiniteStateMachine : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		//////////////////////////////////////
		////////// Compute Resource //////////
		
		private AState _nextState;
		
		/////////////////////////////////
		////////// Information //////////
		
		////////// Data //////////
		
		private object[] _datas;
		
		////////// State //////////
		
		[CustomHeader("Information")]
		[SerializeField, DisableInInspector(1)] private AState _currentState;
		[SerializeField, DisableInInspector(1)] private AState _previousState;
		
		/////////////////////////////
		////////// Setting //////////

		[CustomHeader("Setting")]
		[SerializeField, IndentLevel(1)] private AState _entryState;
		[SerializeField, IndentLevel(1)] private bool _useDebugLog;
		
		/////////////////////////////////////
		////////// Warning Message //////////
		
		private const string NoEntryStateMessage = "[PluggableFiniteStateMachine] There is no Entry State!";
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		////////////////////////////////////////////
		////////// MonoBehaviour Callback //////////

		private void Awake()
		{
			Initialize();
		}

		private void FixedUpdate()
		{
			if (_currentState != null && _datas != null)
				RunCurrentState();
		}

		private void Update()
		{
			if (_currentState != null && _datas != null)
				AttemptToTransit();
		}

		/////////////////////////////////////////////////
		////////// PluggableFiniteStateMachine //////////
		
		////////// API //////////
		
		/// <summary>
		/// Updates the pluggable finite state machine datas
		/// </summary>
		/// <param name="datas">The new pluggable finite state machine datas</param>
		public void UpdateDatas(params object[] datas)
		{
			_datas = datas;
		}
		
		////////// Service //////////
		
		/// <summary>
		/// Attempts to transit to a next state
		/// </summary>
		private void AttemptToTransit()
		{
			_nextState = _currentState.AttemptToGetNextState(_datas);
			
			if (_nextState != null)
			{
				_previousState = _currentState;
				_currentState = _nextState;
				if (_useDebugLog)
					DisplayDebugLog();
			}
		}

		/// <summary>
		/// Display on the console the current transition
		/// </summary>
		private void DisplayDebugLog()
		{
			Debug.Log(_previousState + " -> " + _currentState);
		}
		
		/// <summary>
		/// Initializes the pluggable finite state machine
		/// </summary>
		private void Initialize()
		{
			if (_entryState != null)
				_currentState = _entryState;
			else
				Debug.LogError(NoEntryStateMessage);
		}
		
		/// <summary>
		/// Runs the current state
		/// </summary>
		private void RunCurrentState()
		{
			_currentState.Run(_datas);
		}
	}
}
