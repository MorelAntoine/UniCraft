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
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		/// <summary>
		/// Attempts to transit to a next state
		/// </summary>
		public void AttemptToTransit()
		{
			_nextState = _currentState.AttemptToGetNextState(_datas);
			
			if (_nextState != null)
			{
				_previousState = _currentState;
				_currentState = _previousState;
			}
		}

		/// <summary>
		/// Runs the current state
		/// </summary>
		public void RunCurrentState()
		{
			_currentState.Run(_datas);
		}

		/// <summary>
		/// Updates the pluggable finite state machine datas
		/// </summary>
		/// <param name="datas">The new pluggable finite state machine datas</param>
		public void UpdateDatas(params object[] datas)
		{
			_datas = datas;
		}
	}
}
