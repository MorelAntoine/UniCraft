using UnityEngine;

namespace UniCraft.Character.System.Core.Context
{
	[global::System.Serializable]
	public class CharacterContext2D : ACharacterContext
	{
		////////////////////////////////
		////////// Attributes //////////

		////////// Components //////////
		
		private Collider2D _collider2D;
		private Rigidbody2D _rigidbody2D;
		
		////////// Resources //////////

		private readonly RaycastHit2D[] _raycastHit2Ds = new RaycastHit2D[8];
		
		////////////////////////////////
		////////// Properties //////////
		
		/////////////////////////////
		////////// Methods //////////

		////////// Context checks //////////

		public override bool IsGrounded()
		{
			LastIsGroundedCheck = false;
			for (var i = 0; i < _rigidbody2D.Cast(-_collider2D.transform.up, _raycastHit2Ds, MinGroundDistance); i++)
			{
				if (!(_raycastHit2Ds[i].normal.y >= MinGroundNormal))
					continue;
				LastIsGroundedCheck = true;
				return (LastIsGroundedCheck);
			}
			return (LastIsGroundedCheck);
		}

		////////// Initialization //////////
		
		public override void Initialize(object collider, object rigidbody)
		{
			_collider2D = collider as Collider2D;
			_rigidbody2D = rigidbody as Rigidbody2D;
		}
	}
}
