using UnityEngine;

namespace UniCraft.Character.Mechanism.System.Context.Environment
{
	[global::System.Serializable]
	public class EnvironmentContext3D
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		private Collider _collider;
		private Rigidbody _rigidbody;
		[SerializeField] private float _groundCheckDistance;
		[SerializeField] private float _groundNormal;
		private RaycastHit _lastGroundRaycastHit;
		[SerializeField] private bool _lastIsGroundedResult;
		[SerializeField] private float _skinWidth;

		private RaycastHit[] _raycastHits = new RaycastHit[3];
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public RaycastHit LastGroundRaycastHit
		{
			get { return _lastGroundRaycastHit; }
		}

		public bool LastIsGroundedResult
		{
			get { return _lastIsGroundedResult; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		/// <summary>
		/// Initialize the environment context 3D
		/// </summary>
		public void Initialize(Collider collider, Rigidbody rigidbody)
		{
			_collider = collider;
			_rigidbody = rigidbody;
			_rigidbody.interpolation = RigidbodyInterpolation.None; // Unused
		}

		/// <summary>
		/// Verify if the character is grounded
		/// </summary>
		public bool IsGrounded()
		{
			var nbrHits = Physics.RaycastNonAlloc(_collider.bounds.center, -_collider.gameObject.transform.up,
				_raycastHits, _collider.bounds.extents.y + _groundCheckDistance + _skinWidth);

			_lastIsGroundedResult = false;
			for (var i = 1; i < nbrHits; i++)
			{
				_lastIsGroundedResult = _raycastHits[i].normal.x <= _groundNormal || _raycastHits[i].normal.z <= _groundNormal;
				if (_lastIsGroundedResult == false) continue;
				_lastGroundRaycastHit = _raycastHits[i];
				return (_lastIsGroundedResult);
			}
			return (false);
		}
		
	}
}
