using UnityEngine;

namespace UniCraft.Character.System.Core.Context
{
	[global::System.Serializable]
	public class CharacterContext : ACharacterContext
	{
		////////////////////////////////
		////////// Attributes //////////

		////////// Components //////////
		
		private Collider _collider;
		private Rigidbody _rigidbody;
		
		////////// Resources //////////

		private Vector3 _computedPosition = Vector3.zero;
		private int _numberOfResults;
		private readonly RaycastHit[] _raycastHits = new RaycastHit[16];
		
		////////////////////////////////
		////////// Properties //////////
		
		/////////////////////////////
		////////// Methods //////////

		////////// Context checks //////////

		public override bool IsGrounded()
		{
			_computedPosition.Set(_rigidbody.position.x, _rigidbody.position.y - _collider.bounds.extents.y,
				_rigidbody.position.z);
			_numberOfResults = Physics.SphereCastNonAlloc(_computedPosition, _collider.bounds.extents.x,
				-_rigidbody.transform.up, _raycastHits, MinGroundDistance);
			LastIsGroundedCheck = false;
			
			for (var i = 0; i < _numberOfResults; i++)
			{
				if (!(_raycastHits[i].normal.y >= MinGroundNormal)) continue;
				LastIsGroundedCheck = true;
				return (LastIsGroundedCheck);
			}
			return (LastIsGroundedCheck);
		}

		////////// Initialization //////////
		
		public override void Initialize(object collider, object rigidbody)
		{
			_collider = collider as Collider;
			_rigidbody = rigidbody as Rigidbody;
		}
	}
}
