using UniCraft.Toolbox.Attribute;
using UnityEngine;

namespace UniCraft.Character.System.Core.Context
{
	[global::System.Serializable]
	public abstract class ACharacterContext
	{
		////////////////////////////////
		////////// Attributes //////////

		////////// Information //////////
		
		[DisableInInspector, SerializeField] private bool _lastIsGroundedCheck;

		////////// Settings //////////

		[SerializeField, Range(0.01f, 0.1f)] private float _minGroundDistance = 0.05f;
		[SerializeField, Range(0.6f, 1f)] private float _minGroundNormal = 0.8f;
		
		////////////////////////////////
		////////// Properties //////////

		////////// Information //////////
		
		public bool LastIsGroundedCheck
		{
			get { return _lastIsGroundedCheck; }
			protected set { _lastIsGroundedCheck = value; }
		}

		////////// Settings //////////

		public float MinGroundDistance
		{
			get { return _minGroundDistance; }
			set { _minGroundDistance = value; }
		}

		public float MinGroundNormal
		{
			get { return _minGroundNormal; }
			set { _minGroundNormal = value; }
		}

		/////////////////////////////
		////////// Methods //////////

		////////// Context checks //////////
		
		public abstract bool IsGrounded();
		
		////////// Initialization //////////

		public abstract void Initialize(object collider, object rigidbody);
	}
}
