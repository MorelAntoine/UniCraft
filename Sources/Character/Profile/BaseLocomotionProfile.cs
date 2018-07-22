using UnityEngine;

namespace UniCraft.Character.Profile
{
	/// <summary>
	/// Profile class used to contains all the base locomotion attributes of a character
	/// </summary>
	[global::System.Serializable]
	public class BaseLocomotionProfile
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		[SerializeField, Range(60f, 120f)] private float _angularSpeed = 88f;
		[SerializeField, Range(0f, 3f)] private float _crouchSpeed = 1.3f;
		[SerializeField, Range(0f, 14f)] private float _glideSpeed = 7f;
		[SerializeField, Range(0f, 5f)] private float _jumpHeight = 2.4f;
		[SerializeField, Range(0f, 12f)] private float _runSpeed = 6.8f;
		[SerializeField, Range(100f, 160f)] private float _stationaryAngularSpeed = 122f;
		[SerializeField, Range(0f, 6f)] private float _walkSpeed = 2.4f;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public float AngularSpeed
		{
			get { return _angularSpeed; }
			set { _angularSpeed = value; }
		}

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

		public float StationaryAngularSpeed
		{
			get { return _stationaryAngularSpeed; }
			set { _stationaryAngularSpeed = value; }
		}

		public float WalkSpeed
		{
			get { return _walkSpeed; }
			set { _walkSpeed = value; }
		}
	}
}
