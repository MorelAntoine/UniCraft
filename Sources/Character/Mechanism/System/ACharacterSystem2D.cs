using UniCraft.Character.Mechanism.System.Context.Environment;
using UnityEngine;

namespace UniCraft.Character.Mechanism.System
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

		private Collider2D _collider2D;
		private Rigidbody2D _rigidbody2D;
		[SerializeField] private EnvironmentContext2D _environmentContext2D;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public Collider2D Collider2D
		{
			get { return _collider2D; }
		}

		public Rigidbody2D Rigidbody2D
		{
			get { return _rigidbody2D; }
		}

		public EnvironmentContext2D EnvironmentContext2D
		{
			get { return _environmentContext2D; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		protected override void Awake()
		{
			base.Awake();
			_environmentContext2D.Initialize(GetComponent<Collider2D>(), GetComponent<Rigidbody2D>());
		}
		
		protected override void LoadComponents()
		{
			base.LoadComponents();
			_collider2D = GetComponent<Collider2D>();
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}
	}
}
