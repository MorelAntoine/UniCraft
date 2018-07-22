using UniCraft.EnvironmentContext;
using UnityEngine;

namespace UniCraft.Character.System
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to create a character system 3D
	/// </summary>
	[RequireComponent(typeof(Collider), typeof(EnvironmentContext3D), typeof(Rigidbody))]
	public abstract class ACharacterSystem3D : ACharacterSystem
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		private Collider _collider;
		private EnvironmentContext3D _environmentContext3D;
		private Rigidbody _rigidbody;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public Collider Collider
		{
			get { return _collider; }
		}

		public EnvironmentContext3D EnvironmentContext3D
		{
			get { return _environmentContext3D; }
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
			_collider = GetComponent<Collider>();
			_environmentContext3D = GetComponent<EnvironmentContext3D>();
			_rigidbody = GetComponent<Rigidbody>();
		}
	}
}
