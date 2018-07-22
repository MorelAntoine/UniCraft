using UniCraft.EnvironmentContext;
using UnityEngine;

namespace UniCraft.Character.System
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to create a character system 2D
	/// </summary>
	[RequireComponent(typeof(Collider2D), typeof(EnvironmentContext2D), typeof(Rigidbody2D))]
	public abstract class ACharacterSystem2D : ACharacterSystem
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		private Collider2D _collider2D;
		private EnvironmentContext2D _environmentContext2D;
		private Rigidbody2D _rigidbody2D;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public Collider2D Collider2D
		{
			get { return _collider2D; }
		}

		public EnvironmentContext2D EnvironmentContext2D
		{
			get { return _environmentContext2D; }
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
			_collider2D = GetComponent<Collider2D>();
			_environmentContext2D = GetComponent<EnvironmentContext2D>();
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}
	}
}
