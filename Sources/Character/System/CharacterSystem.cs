using UniCraft.Character.System.Core;
using UnityEngine;

namespace UniCraft.Character.System
{
    [AddComponentMenu("UniCraft/Character/System/CharacterSystem")]
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class CharacterSystem : ACharacterSystem
    {
        ////////////////////////////////
        ////////// Attributes //////////

        private Collider _collider;
        private Rigidbody _rigidbody;
        
        ////////////////////////////////
        ////////// Properties //////////
        
        public Collider Collider
        {
            get { return _collider; }
        }

        public Rigidbody Rigidbody
        {
            get { return _rigidbody; }
        }
        
        /////////////////////////////
        ////////// Methods //////////
        
        protected override void Initialize()
        {
            _collider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
