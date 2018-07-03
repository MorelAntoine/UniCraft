using UnityEngine;

namespace UniCraft.Context.GameObject
{
	[AddComponentMenu("UniCraft/Context/GameObjectContext")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Collider))]
	public sealed class GameObjectContext : MonoBehaviour, IGameObjectContext
	{
		////////////////////////////////
		////////// Attributes //////////
		
		////////// Components //////////

		private Collider _collider;
		
		////////// Information //////////
		
		[Header("Information")]
		[SerializeField] private bool _lastIsGrounded;
		
		////////// Resources //////////

		private readonly Vector3 _downDirection = Vector3.down;
		private readonly RaycastHit[] _rh = new RaycastHit[1];
		
		////////// Settings //////////

		[Header("Settings")]
		[SerializeField, Range(0.0f, 0.5f)] private float _maxGroundNormal = 0.35f;
		[SerializeField, Range(0.01f, 0.1f)] private float _skinWidth = 0.05f;
		
		/////////////////////////////
		////////// Methods //////////
		
		////////// GameObjectContext //////////
		
		public bool IsGrounded()
		{
			if (Physics.RaycastNonAlloc(transform.position, _downDirection, _rh,_collider.bounds.extents.y + _skinWidth) == 0)
				return (false);
			_lastIsGrounded = Mathf.Abs(_rh[0].normal.x) <= _maxGroundNormal && Mathf.Abs(_rh[0].normal.z) <= _maxGroundNormal;
			return (_lastIsGrounded);
		}
		
		////////// MonoBehaviour //////////

		private void Awake()
		{
			_collider = GetComponent<Collider>();
		}

		private void FixedUpdate()
		{
			ResetInformationValues();
			IsGrounded();
		}
		
		////////// Services //////////

		private void ResetInformationValues()
		{
			_lastIsGrounded = false;
		}
	}
}
