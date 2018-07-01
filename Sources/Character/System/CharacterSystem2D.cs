using UniCraft.Character.System.Core;
using UnityEngine;

namespace UniCraft.Character.System
{
	[AddComponentMenu("UniCraft/Character/System/CharacterSystem2D")]
	[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
	public class CharacterSystem2D : ACharacterSystem
	{
		////////////////////////////////
		////////// Attributes //////////

		private Collider2D _collider2D;
		private Rigidbody2D _rigidbody2D;
        
		////////////////////////////////
		////////// Properties //////////
        
		public Collider2D Collider2D
		{
			get { return _collider2D; }
		}

		public Rigidbody2D Rigidbody2D
		{
			get { return _rigidbody2D; }
		}

		/////////////////////////////
		////////// Methods //////////
        
		protected override void Initialize()
		{
			_collider2D = GetComponent<Collider2D>();
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}
	}
}
