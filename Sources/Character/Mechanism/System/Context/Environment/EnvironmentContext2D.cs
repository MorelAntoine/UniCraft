using UnityEngine;

namespace UniCraft.Character.Mechanism.System.Context.Environment
{
	/// <summary>
	/// Context class used to obtain information between the character and the environment in 2D space
	/// </summary>
	[global::System.Serializable]
	public class EnvironmentContext2D
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		private Collider2D _collider2D;
		private Rigidbody2D _rigidbody2D;
		[SerializeField] private float _groundCheckDistance;
		[SerializeField] private float _groundNormal;
		private RaycastHit2D _lastGroundRaycastHit2D;
		[SerializeField] private bool _lastIsGroundedResult;
		[SerializeField] private float _skinWidth;

		private RaycastHit2D[] _raycastHits2D = new RaycastHit2D[3];
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public RaycastHit2D LastGroundRaycastHit2D
		{
			get { return _lastGroundRaycastHit2D; }
		}

		public bool LastIsGroundedResult
		{
			get { return _lastIsGroundedResult; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		/// <summary>
		/// Initialize the environment context 2D
		/// </summary>
		public void Initialize(Collider2D collider2D, Rigidbody2D rigidbody2D)
		{
			_collider2D = collider2D;
			_rigidbody2D = rigidbody2D;
		}
		
		/// <summary>
		/// Verify if the character is grounded
		/// </summary>
		public bool IsGrounded()
		{
			var nbrHits = _rigidbody2D.Cast(-_collider2D.gameObject.transform.up, _raycastHits2D,
				_collider2D.bounds.extents.y + _groundCheckDistance + _skinWidth);

			_lastIsGroundedResult = false;
			for (var i = 0; i < nbrHits; i++)
			{
				_lastIsGroundedResult = _raycastHits2D[i].normal.x <= _groundNormal;
				if (!_lastIsGroundedResult) continue;
				_lastGroundRaycastHit2D = _raycastHits2D[i];
				return (_lastIsGroundedResult);
			}
			return (false);
		}
	}
}
