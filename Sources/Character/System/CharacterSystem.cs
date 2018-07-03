using UniCraft.Character.System.Core;
using UniCraft.Character.System.Core.Context;
using UnityEngine;

namespace UniCraft.Character.System
{
    [AddComponentMenu("UniCraft/Character/System/CharacterSystem")]
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class CharacterSystem : ACharacterSystem
    {
        ////////////////////////////////
        ////////// Attributes //////////

        ////////// Components //////////
        
        private Collider _collider;
        private Rigidbody _rigidbody;

        ////////// Context Information //////////
        
        [Header("Context Information")]
        [SerializeField] private CharacterContext _context;
        
        ////////////////////////////////
        ////////// Properties //////////
        
        ////////// Components //////////
        
        public Collider Collider
        {
            get { return _collider; }
        }

        public Rigidbody Rigidbody
        {
            get { return _rigidbody; }
        }

        ////////// Context Information //////////
        
        public CharacterContext Context
        {
            get { return _context; }
        }
        
        /////////////////////////////
        ////////// Methods //////////
        
        protected override void Initialize()
        {
            _collider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();
            _context.Initialize(_collider, _rigidbody);
        }
    }
}
