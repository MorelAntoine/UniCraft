using UniCraft.Character.Mechanism.System.Motion.Information;
using UniCraft.Character.Mechanism.System.Motion.StateMachine;
using UniCraft.Character.Mechanism.System.Profile;
using UnityEngine;

namespace UniCraft.Character.Mechanism.System
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create a character system
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public abstract class ACharacterSystem : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        private Animator _animator;
        [SerializeField] private LocomotionProfile _locomotionProfile;
        [SerializeField] private MotionInformation _motionInformation;
        [SerializeField] private MotionStateMachine _motionStateMachine;

        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        public Animator Animator
        {
            get { return _animator; }
        }

        public LocomotionProfile LocomotionProfile
        {
            get { return _locomotionProfile; }
            protected set { _locomotionProfile = value; }
        }

        public MotionInformation MotionInformation
        {
            get { return _motionInformation; }
            protected set { _motionInformation = value; }
        }

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        //////////////////////////////
        ////////// Callback //////////

        /// <summary>
        /// Callback to initialize the character system
        /// </summary>
        protected abstract void Initialize();

        /// <summary>
        /// Callback to load the components of the character system
        /// </summary>
        protected virtual void LoadComponents()
        {
            _animator = GetComponent<Animator>();
        }
        
        ////////////////////////////////////////////
        ////////// MonoBehaviour Callback //////////

        protected virtual void Awake()
        {
            _motionStateMachine.Initialize(this);
            LoadComponents();
            Initialize();
        }

        protected virtual void FixedUpdate()
        {
            _motionStateMachine.Execute(this, _motionInformation);
        }

        protected virtual void Update()
        {
            _motionStateMachine.Update(this, _motionInformation);
        }
    }
}
