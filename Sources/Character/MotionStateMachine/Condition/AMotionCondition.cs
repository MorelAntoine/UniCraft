using UniCraft.Character.System;
using UnityEngine;

namespace UniCraft.Character.MotionStateMachine.Condition
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class used to define a condition for the motion state machine
    /// </summary>
    public abstract class AMotionCondition : ScriptableObject
    {
        /// <summary>
        /// Callback used to verify the result of the condtion
        /// </summary>
        /// <param name="cs">The ACharacterSystem of the motion state machine</param>
        /// <param name="mi">The MotionInformation of the motion state machine</param>
        public bool IsComplete(ACharacterSystem cs, MotionInformation mi)
        {
            return (mi.Use3DMode ? IsComplete3D(cs as ACharacterSystem3D, mi) : IsComplete2D(cs as ACharacterSystem2D, mi));
        }

        /// <summary>
        /// Callback used to verify the result of the condition in 2D space
        /// </summary>
        /// <param name="cs2D">The ACharacterSystem2D of the motion state machine</param>
        /// <param name="mi">The MotionInformation of the motion state machine</param>
        protected abstract bool IsComplete2D(ACharacterSystem2D cs2D, MotionInformation mi);
        
        /// <summary>
        /// Callback used to verify the result of the condition in 3D space
        /// </summary>
        /// <param name="cs3D">The ACharacterSystem3D of the motion state machine</param>
        /// <param name="mi">The MotionInformation of the motion state machine</param>
        protected abstract bool IsComplete3D(ACharacterSystem3D cs3D, MotionInformation mi);
    }
}
