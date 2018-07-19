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
        
        [CustomHeader("Configuration")]
        [SerializeField, DisableInInspector(1)] private bool _use3DMode;

        ///////////////////////////
        ////////// Input //////////

        ////////// Action //////////

        [CustomHeader("Action Input")]
        [SerializeField, DisableInInspector(1)] private bool _crouch;
        [SerializeField, DisableInInspector(1)] private bool _jump;
        [SerializeField, DisableInInspector(1)] private bool _run;
        
        ////////// Axis //////////
        
        [CustomHeader("Axis Input")]
        [SerializeField, DisableInInspector(1)] private Vector3 _movementDirection;
        
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

        ////////// Action //////////

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

        ////////// Axis //////////

        public Vector3 MovementDirection
        {
            get { return _movementDirection; }
            set { _movementDirection = value; }
        }
    }
}
