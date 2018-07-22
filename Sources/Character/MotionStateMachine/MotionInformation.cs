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

        ///////////////////////////////////
        ////////// Configuration //////////
        
        private bool _use3DMode;

        ///////////////////////////
        ////////// Input //////////

        [DisableInInspector] public Vector3 Direction;
        [SerializeField, DisableInInspector] private bool _crouch;
        [SerializeField, DisableInInspector] private bool _jump;
        [SerializeField, DisableInInspector] private bool _run;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        ///////////////////////////////////
        ////////// Configuration //////////

        public bool Use3DMode
        {
            get { return _use3DMode; }
            set { _use3DMode = value; }
        }

        ///////////////////////////
        ////////// Input //////////

        public bool Crouch
        {
            get { return _crouch; }
            set { _crouch = value; }
        }

        public bool Jump
        {
            get { return _jump; }
            set { _jump = value; }
        }

        public bool Run
        {
            get { return _run; }
            set { _run = value; }
        }
    }
}
