using UniCraft.Attribute;
using UnityEngine;

namespace UniCraft.Toolbox.PluggableFiniteStateMachine.State
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to derived to create a state for the pluggable finite state machine
    /// </summary>
    public abstract class AState : ScriptableObject
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        //////////////////////////////////////
        ////////// Compute Resource //////////
        
        private AState _nextState;
        
        /////////////////////////////
        ////////// Setting //////////
        
        [CustomHeader("Setting")]
        [SerializeField, IndentLevel(1)] private Transition.Transition[] _transitions;

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        /// <summary>
        /// (!Can return null!) Attempts to get the next state by cheking all the conditions
        /// </summary>
        /// <param name="datas">The finite state machine datas</param>
        public AState AttemptToGetNextState(object[] datas)
        {
            foreach (var t in _transitions)
            {
                _nextState = t.AttemptToGetNextState(datas);
                if (_nextState != null)
                    return (_nextState);
            }
            return (null);
        }
        
        /// <summary>
        /// Runs the action of the state
        /// </summary>
        /// <param name="datas">The finite state machine datas</param>
        public abstract void Run(object[] datas);
    }
}
