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
		
		protected object[] Datas;
		
		////////// State //////////
		
		[CustomHeader("Information")]
		[SerializeField, DisableInInspector(1)] protected AState CurrentState;
		[SerializeField, DisableInInspector(1)] protected AState PreviousState;
		
		/////////////////////////////
		////////// Setting //////////

		[CustomHeader("Setting")]
		[SerializeField, IndentLevel(1)] protected AState EntryState;
		[SerializeField, IndentLevel(1)] protected bool UseDebugLog;
		
		/////////////////////////////////////
		////////// Warning Message //////////
		
		private const string NoEntryStateMessage = "[PluggableFiniteStateMachine] There is no Entry State!";
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		////////////////////////////////////////////
		////////// MonoBehaviour Callback //////////

		protected virtual void Awake()
		{
			Initialize();
		}

		protected virtual void FixedUpdate()
		{
			if (CurrentState != null && Datas != null)
				RunCurrentState();
		}

		protected virtual void Update()
		{
			if (CurrentState != null && Datas != null)
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
			Datas = datas;
		}
		
		////////// Service //////////
		
		/// <summary>
		/// Attempts to transit to a next state
		/// </summary>
		private void AttemptToTransit()
		{
			_nextState = CurrentState.AttemptToGetNextState(Datas);
			
			if (_nextState != null)
			{
				PreviousState = CurrentState;
				CurrentState = _nextState;
				if (UseDebugLog)
					DisplayDebugLog();
			}
		}

		/// <summary>
		/// Display on the console the current transition
		/// </summary>
		protected virtual void DisplayDebugLog()
		{
			Debug.Log(PreviousState + " -> " + CurrentState);
		}
		
		/// <summary>
		/// Initializes the pluggable finite state machine
		/// </summary>
		protected virtual void Initialize()
		{
			if (EntryState != null)
				CurrentState = EntryState;
			else
				Debug.LogError(NoEntryStateMessage);
		}
		
		/// <summary>
		/// Runs the current state
		/// </summary>
		private void RunCurrentState()
		{
			CurrentState.Run(Datas);
		}
	}
}
