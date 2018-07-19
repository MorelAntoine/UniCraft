using UnityEngine;

namespace UniCraft.Character.Profile.Attribute
{
    [global::System.Serializable]
    public class LocomotionAttributeProfile
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField, Range(0f, 4f)] private float _crouchSpeed = 1.2f;
        [SerializeField, Range(0f, 20f)] private float _glideSpeed = 6.8f;
        [SerializeField, Range(0f, 6f)] private float _jumpHeight = 2.7f;
        [SerializeField, Range(0f, 20f)] private float _runSpeed = 5.8f;
        [SerializeField, Range(60f, 140f)] private float _turnSpeed = 88f;
        [SerializeField, Range(0f, 8f)] private float _walkSpeed = 2.4f;

        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        public float CrouchSpeed
        {
            get { return _crouchSpeed; }
            set { _crouchSpeed = value; }
        }

        public float GlideSpeed
        {
            get { return _glideSpeed; }
            set { _glideSpeed = value; }
        }

        public float JumpHeight
        {
            get { return _jumpHeight; }
            set { _jumpHeight = value; }
        }

        public float RunSpeed
        {
            get { return _runSpeed; }
            set { _runSpeed = value; }
        }

        public float TurnSpeed
        {
            get { return _turnSpeed; }
            set { _turnSpeed = value; }
        }

        public float WalkSpeed
        {
            get { return _walkSpeed; }
            set { _walkSpeed = value; }
        }
    }
}
