using System.Linq;
using UniCraft.Attribute;
using UniCraft.Character.MotionStateMachine.Condition;
using UniCraft.Character.MotionStateMachine.State;
using UniCraft.Character.System;
using UnityEngine;

namespace UniCraft.Character.MotionStateMachine.Transition
{
    /// <inheritdoc/>
    /// <summary>
    /// Class used to create transition for the motion state machine
    /// </summary>
    [CreateAssetMenu(menuName = "UniCraft/Character/Motion/Transition")]
    public class MotionTransition : ScriptableObject
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        /////////////////////////////
        ////////// Setting //////////
        
        [SectionHeader("SETTING")]
        
        ////////// Condition //////////
        
        [SerializeField] private AMotionCondition[] _conditions;
        
        ////////// Exit State //////////
        
        [CustomHeader("Exit State")]
        [SerializeField, IndentLevel(1)] private AMotionState _stateOnSuccess;
        [SerializeField, IndentLevel(1)] private AMotionState _stateOnFailure;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        /// <summary>
        /// Checks if all the conditions are met
        /// </summary>
        /// <param name="cs">The ACharacterSystem of the motion state machine</param>
        /// <param name="mi">The MotionInformation of the motion state machine</param>
        private bool AreConditionsMet(ACharacterSystem cs, MotionInformation mi)
        {
            return (_conditions.All(c => c.IsComplete(cs, mi)));
        }

        /// <summary>
        /// Attempts the get the correct exit state based on the conditions simulation
        /// </summary>
        /// <param name="cs">The ACharacterSystem of the motion state machine</param>
        /// <param name="mi">The MotionInformation of the motion state machine</param>
        public AMotionState AttemptToGetExitStateFromSimulation(ACharacterSystem cs, MotionInformation mi)
        {
            return ((AreConditionsMet(cs, mi) ? _stateOnSuccess : _stateOnFailure));
        }
    }
}
