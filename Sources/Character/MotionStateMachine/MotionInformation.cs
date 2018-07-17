using UniCraft.Attribute;
using UnityEngine;

namespace UniCraft.Character.MotionStateMachine
{
    /// <summary>
    /// Information class used to contains all the information needed for the motion state machine
    /// </summary>
    [global::System.Serializable]
    public class MotionInformation
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        ////////////////////////////////////////////////////////
        ////////// Motion State Machine Configuration //////////
        
        [CustomHeader("Motion State Machine Configuration", 1)]
        [SerializeField, DisableInInspector(2)] private bool _use3DMode;

        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////
        
        ////////////////////////////////////////////////////////
        ////////// Motion State Machine Configuration //////////

        public bool Use3DMode
        {
            get { return _use3DMode; }
            set { _use3DMode = value; }
        }
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        /// <summary>
        /// Resets all the MotionInformation datas
        /// </summary>
        public void Reset()
        {}
    }
}
