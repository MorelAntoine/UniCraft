using UnityEngine;

namespace UniCraft.Toolbox.PluggableFiniteStateMachine.Condition
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to derived to create a condition for the pluggable finite state machine
	/// </summary>
	public abstract class ACondition : ScriptableObject
	{
		/// <summary>
		/// Checks if the condition is completed
		/// </summary>
		/// <param name="datas">The finite state machine datas</param>
		public abstract bool IsComplete(object[] datas);
	}
}
