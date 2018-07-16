using System.Linq;
using UniCraft.Attribute;
using UniCraft.Toolbox.PluggableFiniteStateMachine.Condition;
using UniCraft.Toolbox.PluggableFiniteStateMachine.State;
using UnityEngine;

namespace UniCraft.Toolbox.PluggableFiniteStateMachine.Transition
{
	/// <inheritdoc/>
	/// <summary>
	/// Class used to create Transition for the pluggable finite state machine
	/// </summary>
	[CreateAssetMenu(menuName = "UniCraft/FiniteStateMachine/Transition")]
	public class Transition : ScriptableObject
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		/////////////////////////////
		////////// Setting //////////
		
		////////// Condition //////////
		
		[CustomHeader("Condition")]
		[SerializeField, IndentLevel(1)] private ACondition[] _conditions;

		////////// State //////////
		
		[CustomHeader("State")]
		[SerializeField, IndentLevel(1)] private AState _stateOnSuccess;
		[SerializeField, IndentLevel(1)] private AState _stateOnFailure;
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		/// <summary>
		/// Checks if all the conditions are met
		/// </summary>
		/// <param name="datas">The finite state machine datas</param>
		private bool AreConditionsComplete(object[] datas)
		{
			return (_conditions.Any(c => c.IsComplete(datas) == false));
		}

		/// <summary>
		/// (!Can return null!) Attempts to get the next state by cheking all the conditions
		/// </summary>
		/// <param name="datas">The finite state machine datas</param>
		public AState AttemptToGetNextState(object[] datas)
		{
			return (AreConditionsComplete(datas) ? _stateOnSuccess : _stateOnFailure);
		}
	}
}
