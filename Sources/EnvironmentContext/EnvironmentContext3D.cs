using UniCraft.Attribute;
using UnityEngine;

namespace UniCraft.EnvironmentContext
{
	/// <inheritdoc/>
	/// <summary>
	/// Component class used to obtain information between the GameObject and the 3D environment
	/// </summary>
	[AddComponentMenu("UniCraft/EnvironmentContext3D")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Collider))]
	public class EnvironmentContext3D : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		///////////////////////////////
		////////// Component //////////

		private Collider _collider;
		
		//////////////////////////////////////
		////////// Compute Resource //////////

		private readonly RaycastHit[] _groundRaycastHits = new RaycastHit[4];
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
		////////// EnvironmentContext3D Mechanism //////////

		private void UpdateIsGroundedValue()
		{
			_isGrounded = false;
			_numberOfHits = Physics.RaycastNonAlloc(transform.position, Vector3.down, _groundRaycastHits,
				_groundDistance + _skinWidth + _collider.bounds.extents.y);
			for (var i = 0; i < _numberOfHits; i++)
			{
				_isGrounded = Mathf.Abs(_groundRaycastHits[i].normal.x) <= _groundNormal
				              && Mathf.Abs(_groundRaycastHits[i].normal.z) <= _groundNormal;
				if (_isGrounded)
					break;
			}
		}
		
		////////////////////////////////////////////
		////////// MonoBehaviour Callback //////////

		private void Awake()
		{
			_collider = GetComponent<Collider>();
		}
		
		private void FixedUpdate()
		{
			UpdateIsGroundedValue();
		}
	}
}
