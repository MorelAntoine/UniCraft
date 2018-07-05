using UniCraft.Character.System.Core;
using UniCraft.Toolbox.Component.GameObjectContext;
using UnityEngine;

namespace UniCraft.Character.System
{
    [AddComponentMenu("UniCraft/Character/System/CharacterSystem")]
    [RequireComponent(typeof(Collider), typeof(GameObjectContext), typeof(Rigidbody))]
    public class CharacterSystem : ACharacterSystem
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        private Collider _collider;
        private GameObjectContext _context;
        private Rigidbody _rigidbody;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////
        
        public Collider Collider
        {
            get { return _collider; }
        }

        public GameObjectContext Context
        {
            get { return _context; }
        }

        public Rigidbody Rigidbody
        {
            get { return _rigidbody; }
        }
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        protected override void Initialize()
        {
            _collider = GetComponent<Collider>();
            _context = GetComponent<GameObjectContext>();
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
