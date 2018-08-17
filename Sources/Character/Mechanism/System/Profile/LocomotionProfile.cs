using UnityEngine;

namespace UniCraft.Character.Mechanism.System.Profile
{
	/// <summary>
	/// Profile class containing all the locomotion settings
	/// </summary>
	[global::System.Serializable]
	public class LocomotionProfile
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		[SerializeField] private float _angularSpeed;
		[SerializeField] private float _angularSpeedStationary;
		[SerializeField] private float _crouchSpeed;
		[SerializeField] private float _glideSpeed;
		[SerializeField] private float _jumpHeight;
		[SerializeField] private float _runSpeed;
		[SerializeField] private float _walkSpeed;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public float AngularSpeed
		{
			get { return _angularSpeed; }
			set { _angularSpeed = value; }
		}

		public float AngularSpeedStationary
		{
			get { return _angularSpeedStationary; }
			set { _angularSpeedStationary = value; }
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

		public float WalkSpeed
		{
			get { return _walkSpeed; }
			set { _walkSpeed = value; }
		}
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////

		/// <summary>
		/// Linearly interpolates between AngularSpeedStationary and AngularSpeed by the interpolation coefficient
		/// </summary>
		public float LerpAngularSpeed(float coefficient)
		{
			return (Mathf.Lerp(_angularSpeedStationary, _angularSpeed, coefficient));
		}
	}
}
