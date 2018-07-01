using UnityEngine;

namespace UniCraft.Character.System.Core.Profile
{
	/// <inheritdoc/>
	/// <summary>
	/// Component class used by ACharacterSystem to hold attribute information
	/// </summary>
	[DisallowMultipleComponent]
	public class AttributesProfile : MonoBehaviour
	{
		////////////////////////////////
		////////// Attributes //////////
		
		////////// Locomotion settings //////////

		[Header("Locomotion settings")]
		[SerializeField, Range(0f, 8f)] private float _jumpHeight = 1.5f;
		[SerializeField, Range(0f, 10f)] private float _runSpeed = 5.4f;
		[SerializeField, Range(0f, 4f)] private float _walkSpeed = 1.8f;

		////////////////////////////////
		////////// Properties //////////

		////////// Locomotion settings //////////

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
