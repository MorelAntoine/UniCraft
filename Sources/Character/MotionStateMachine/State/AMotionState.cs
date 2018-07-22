﻿using UniCraft.Character.MotionStateMachine.Transition;
using UniCraft.Character.System;
using UnityEngine;

namespace UniCraft.Character.MotionStateMachine.State
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class used to define a state for the motion state machine
    /// </summary>
    public abstract class AMotionState : ScriptableObject
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        //////////////////////////////////////
        ////////// Compute Resource //////////

        private AMotionState _nextState;
        
        /////////////////////////////
        ////////// Setting //////////
        
        [SerializeField] private MotionTransition[] _transitions;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        /// <summary>
        /// Attempts to get the next motion state
        /// </summary>
        /// <param name="cs">The ACharacterSystem of the motion state machine</param>
        /// <param name="mi">The MotionInformation of the motion state machine</param>
        public AMotionState AttemptToGetNextMotionState(ACharacterSystem cs, MotionInformation mi)
        {
            foreach (var t in _transitions)
            {
                _nextState = t.AttemptToGetExitStateFromSimulation(cs, mi);
                if (_nextState != null)
                    return (_nextState);
            }
            return (null);
        }

        /// <summary>
        /// Runs the state action
        /// </summary>
        /// <param name="cs">The ACharacterSystem of the motion state machine</param>
        /// <param name="mi">The MotionInformation of the motion state machine</param>
        public void Move(ACharacterSystem cs, MotionInformation mi)
        {
            if (mi.Use3DMode)
                Move3D(cs as ACharacterSystem3D, mi);
            else
                Move2D(cs as ACharacterSystem2D, mi);
        }

        /// <summary>
        /// Runs the state action for the 2D space
        /// </summary>
        /// <param name="cs2D">The ACharacterSystem2D of the motion state machine</param>
        /// <param name="mi">The MotionInformation of the motion state machine</param>
        protected abstract void Move2D(ACharacterSystem2D cs2D, MotionInformation mi);
        
        /// <summary>
        /// Runs the state action for the 3D space
        /// </summary>
        /// <param name="cs3D">The ACharacterSystem3D of the motion state machine</param>
        /// <param name="mi">The MotionInformation of the motion state machine</param>
        protected abstract void Move3D(ACharacterSystem3D cs3D, MotionInformation mi);
    }
}
