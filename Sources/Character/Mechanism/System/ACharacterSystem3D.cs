using UniCraft.Character.Mechanism.System.Context.Environment;
using UnityEngine;

namespace UniCraft.Character.Mechanism.System
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to create a character system 3D
	/// </summary>
	[RequireComponent(typeof(Collider), typeof(Rigidbody))]
	public abstract class ACharacterSystem3D : ACharacterSystem
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		private Collider _collider;
		private Rigidbody _rigidbody;
		[SerializeField] private EnvironmentContext3D _environmentContext3D;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public Collider Collider
		{
			get { return _collider; }
		}

		public Rigidbody Rigidbody
		{
			get { return _rigidbody; }
		}

		public EnvironmentContext3D EnvironmentContext3D
		{
			get { return _environmentContext3D; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		protected override void Awake()
		{
			base.Awake();
			_environmentContext3D.Initialize(GetComponent<Collider>(), GetComponent<Rigidbody>());
		}
		
		protected override void LoadComponents()
		{
			base.LoadComponents();
			_collider = GetComponent<Collider>();
			_rigidbody = GetComponent<Rigidbody>();
		}
	}
}
