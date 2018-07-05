using UnityEngine;

namespace UniCraft.Toolbox.Component.GameObjectContext
{
	[AddComponentMenu("UniCraft/Toolbox/GameObjectContext2D")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Collider2D))]
	public class GameObjectContext2D : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		///////////////////////////////
		////////// Component //////////

		private Collider2D _collider2D;
		
		/////////////////////////////////
		////////// Information //////////
		
		[Header("Information")]
		[SerializeField] private bool _lastIsGroundedResult;
		
		///////////////////////////////
		////////// Resource //////////

		private readonly Vector2 _downDirection = Vector2.down;
		private readonly RaycastHit2D[] _raycastHits2D = new RaycastHit2D[2];
		
		/////////////////////////////
		////////// Setting //////////

		[Header("Setting")]
		[SerializeField, Range(0.0f, 0.5f)] private float _maxGroundNormal = 0.35f;
		[SerializeField, Range(0.01f, 0.1f)] private float _skinWidth = 0.05f;
		
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

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
			if (Physics2D.RaycastNonAlloc(transform.position, _downDirection, _raycastHits2D, _collider2D.bounds.extents.y + _skinWidth) < 2)
				return (false);
			_lastIsGroundedResult = Mathf.Abs(_raycastHits2D[1].normal.x) <= _maxGroundNormal;
			return (_lastIsGroundedResult);
		}
		
		////////////////////////////////////////////
		////////// MonoBehaviour callback //////////

		private void Awake()
		{
			_collider2D = GetComponent<Collider2D>();
		}
	}
}
