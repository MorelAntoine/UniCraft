using UnityEngine;

namespace UniCraft.Character.System.Core.Profile
{
	[global::System.Serializable]
	public sealed class AttributesProfile
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		////////////////////////////////////////
		////////// Locomotion setting //////////

		[Header("Locomotion setting")]
		[SerializeField, Range(0f, 2f)] private float _crouchSpeed = 0.9f;
		[SerializeField, Range(0f, 8f)] private float _jumpHeight = 1.5f;
		[SerializeField, Range(0f, 10f)] private float _runSpeed = 5.4f;
		[SerializeField, Range(30f, 120f)] private float _turnSpeed = 90f;
		[SerializeField, Range(0f, 4f)] private float _walkSpeed = 1.8f;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////
		
		////////////////////////////////////////
		////////// Locomotion setting //////////

		public float CrouchSpeed
		{
			get { return _crouchSpeed; }
			set { _crouchSpeed = value; }
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

		public float TurnSpeed
		{
			get { return _turnSpeed; }
			set { _turnSpeed = value; }
		}

		public float WalkSpeed
		{
			get { return _walkSpeed; }
			set { _walkSpeed = value; }
		}
	}
}
