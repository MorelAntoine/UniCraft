using UnityEngine;

namespace UniCraft.Toolbox.Component.GameObjectContext
{
	[AddComponentMenu("UniCraft/Toolbox/GameObjectContext")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Collider))]
	public sealed class GameObjectContext : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		///////////////////////////////
		////////// Component //////////

		private Collider _collider;
		
		/////////////////////////////////
		////////// Information //////////
		
		[Header("Information")]
		[SerializeField] private bool _lastIsGroundedResult;
		
		///////////////////////////////
		////////// Resource //////////

		private readonly Vector3 _downDirection = Vector3.down;
		private readonly RaycastHit[] _raycastHits = new RaycastHit[1];
		
		/////////////////////////////
		////////// Setting //////////

		[Header("Setting")]
		[SerializeField, Range(0.0f, 0.5f)] private float _maxGroundNormal = 0.35f;
		[SerializeField, Range(0.01f, 0.1f)] private float _skinWidth = 0.05f;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public bool LastIsGroundedResult
		{
			get { return _lastIsGroundedResult; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		///////////////////////////
		////////// Check //////////
		
		public bool IsGrounded()
		{
			_lastIsGroundedResult = false;
			if (Physics.RaycastNonAlloc(transform.position, _downDirection, _raycastHits,_collider.bounds.extents.y + _skinWidth) == 0)
				return (false);
			_lastIsGroundedResult = Mathf.Abs(_raycastHits[0].normal.x) <= _maxGroundNormal && Mathf.Abs(_raycastHits[0].normal.z) <= _maxGroundNormal;
			return (_lastIsGroundedResult);
		}
		
		////////////////////////////////////////////
		////////// MonoBehaviour callback //////////

		private void Awake()
		{
			_collider = GetComponent<Collider>();
		}
	}
}
