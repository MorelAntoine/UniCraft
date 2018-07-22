using UniCraft.Attribute;
using UnityEngine;

namespace UniCraft.EnvironmentContext
{
	/// <inheritdoc/>
	/// <summary>
	/// Component class used to obtain information between the GameObject and the 2D environment
	/// </summary>
	[AddComponentMenu("UniCraft/EnvironmentContext2D")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Collider2D))]
	public class EnvironmentContext2D : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		///////////////////////////////
		////////// Component //////////

		private Collider2D _collider2D;
		
		//////////////////////////////////////
		////////// Compute Resource //////////

		private readonly RaycastHit2D[] _groundRaycastHits2D = new RaycastHit2D[4];
		private int _numberOfHits;
		
		/////////////////////////////////
		////////// Information //////////

		[SectionHeader("Information")]
		[SerializeField, DisableInInspector] private bool _isGrounded;
		
		/////////////////////////////
		////////// Setting //////////

		[SectionHeader("Setting")]
		[SerializeField, Range(0.01f, 0.1f)] private float _groundDistance = 0.01f;
		[SerializeField, Range(0.1f, 0.7f)] private float _groundNormal = 0.33f;
		[SerializeField, Range(0.01f, 0.1f)] private float _skinWidth = 0.05f;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public bool IsGrounded
		{
			get { return _isGrounded; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		////////////////////////////////////////////////////
		////////// EnvironmentContext2D Mechanism //////////

		private void UpdateIsGroundedValue()
		{
			_isGrounded = false;
			_numberOfHits = Physics2D.RaycastNonAlloc(transform.position, Vector3.down, _groundRaycastHits2D,
				_groundDistance + _skinWidth + _collider2D.bounds.extents.y);
			for (var i = 1; i < _numberOfHits; i++)
			{
				_isGrounded = Mathf.Abs(_groundRaycastHits2D[i].normal.x) <= _groundNormal;
				if (_isGrounded)
					break;
			}
		}
		
		////////////////////////////////////////////
		////////// MonoBehaviour Callback //////////

		private void Awake()
		{
			_collider2D = GetComponent<Collider2D>();
		}
		
		private void FixedUpdate()
		{
			UpdateIsGroundedValue();
		}
	}
}
