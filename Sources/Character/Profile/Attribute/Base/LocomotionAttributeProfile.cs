using UnityEngine;

namespace UniCraft.Character.Profile.Attribute.Base
{
	[global::System.Serializable]
	public class LocomotionAttributeProfile
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		[SerializeField, Range(0f, 4f)] private float _crouchSpeed = 2f;
		[SerializeField, Range(0f, 8f)] private float _glideSpeed = 4f;
		[SerializeField, Range(0f, 6f)] private float _jumpHeight = 3f;
		[SerializeField, Range(0f, 16f)] private float _runSpeed = 8f;
		[SerializeField, Range(0f, 8f)] private float _walkSpeed = 4f;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public float CrouchSpeed
		{
			get { return _crouchSpeed; }
			set { _crouchSpeed = value; }
		}

		public float GlideSpeed
		{
			get { return _glideSpeed; }
			set { _glideSpeed = value; }
		}

		public float JumpHeight
		{
			get { return _jumpHeight; }
			set { _jumpHeight = value; }
		}

		public float RunSpeed
		{
			get { return _runSpeed; }
			set { _runSpeed = value; }
		}

		public float WalkSpeed
		{
			get { return _walkSpeed; }
			set { _walkSpeed = value; }
		}
	}
}
