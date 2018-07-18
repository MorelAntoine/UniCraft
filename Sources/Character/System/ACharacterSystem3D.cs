using UniCraft.Attribute;
using UnityEngine;

namespace UniCraft.Character.System
{
	/// <inheritdoc />
	/// <summary>
	/// Base class to create a 3D character system
	/// </summary>
	[RequireComponent(typeof(Collider), typeof(Rigidbody))]
	public abstract class ACharacterSystem3D : ACharacterSystem
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		[CustomHeader("Base Component")]
		[SerializeField, IndentLevel(1)] private Animator _animator;
		[SerializeField, IndentLevel(1)] private Collider _collider;
		[SerializeField, IndentLevel(1)] private Rigidbody _rigidbody;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public Animator Animator
		{
			get { return _animator; }
		}

		public Collider Collider
		{
			get { return _collider; }
		}

		public Rigidbody Rigidbody
		{
			get { return _rigidbody; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		protected override void LoadComponents()
		{
			if (_animator == null) _animator = GetComponent<Animator>();
			if (_collider == null) _collider = GetComponent<Collider>();
			if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody>();
		}
	}
}
