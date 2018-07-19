using UnityEngine;

namespace UniCraft.Character.System
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to create a character system 2D
	/// </summary>
	[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
	public abstract class ACharacterSystem2D : ACharacterSystem
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		[SerializeField] private Animator _animator;
		[SerializeField] private Collider2D _collider2D;
		[SerializeField] private Rigidbody2D _rigidbody2D;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public Animator Animator
		{
			get { return _animator; }
		}

		public Collider2D Collider2D
		{
			get { return _collider2D; }
		}

		public Rigidbody2D Rigidbody2D
		{
			get { return _rigidbody2D; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		protected override void LoadComponents()
		{
			if (_animator == null) _animator = GetComponent<Animator>();
			if (_collider2D == null) _collider2D = GetComponent<Collider2D>();
			if (_rigidbody2D == null) _rigidbody2D = GetComponent<Rigidbody2D>();
		}
	}
}
