using UniCraft.Character.Mechanism.System;
using UniCraft.Character.Mechanism.System.Motion.Information.Configuration;
using UniCraft.Character.Mechanism.System.Motion.Information.Input;
using UnityEngine;

namespace UniCraft.Character.Mechanism.Behaviour
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to create a character behaviour
	/// </summary>
	[DisallowMultipleComponent]
	[RequireComponent(typeof(ACharacterSystem))]
	public abstract class ACharacterBehaviour : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		private ACharacterSystem _characterSystem;

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		//////////////////////////////
		////////// Callback //////////

		/// <summary>
		/// Callback to initialize the character behaviour
		/// </summary>
		protected abstract void Initialize();

		/// <summary>
		/// Callback to update the motion input value in order to control the character system
		/// </summary>
		protected abstract void UpdateMotionInput(ref MotionInput mi);
		
		///////////////////////////////
		////////// Mechanism //////////

		/// <summary>
		/// Setup the motion configuration
		/// </summary>
		protected virtual void SetupMotionConfiguration(ref MotionConfiguration mc)
		{
			mc.ShouldAdaptToNavMesh = false;
		}
		
		////////////////////////////////////////////
		////////// MonoBehaviour Callback //////////

		protected virtual void Awake()
		{
			_characterSystem = GetComponent<ACharacterSystem>();
			Initialize();
			SetupMotionConfiguration(ref _characterSystem.MotionInformation.Configuration);
		}

		protected virtual void Update()
		{
			UpdateMotionInput(ref _characterSystem.MotionInformation.Input);
		}
		
	}
}
