using UniCraft.Character.System.Core;
using UniCraft.Toolbox.Component.GameObjectContext;
using UnityEngine;

namespace UniCraft.Character.System
{
	[AddComponentMenu("UniCraft/Character/System/CharacterSystem2D")]
	[RequireComponent(typeof(Collider2D), typeof(GameObjectContext2D), typeof(Rigidbody2D))]
	public class CharacterSystem2D : ACharacterSystem
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		private Collider2D _collider2D;
		private GameObjectContext2D _context2D;
		private Rigidbody2D _rigidbody2D;
        
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////
		
		public Collider2D Collider2D
		{
			get { return _collider2D; }
		}

		public GameObjectContext2D Context2D
		{
			get { return _context2D; }
		}

		public Rigidbody2D Rigidbody2D
		{
			get { return _rigidbody2D; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		protected override void Initialize()
		{
			_collider2D = GetComponent<Collider2D>();
			_context2D = GetComponent<GameObjectContext2D>();
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}
	}
}
