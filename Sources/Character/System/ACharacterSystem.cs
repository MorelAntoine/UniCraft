using UniCraft.Attribute;
using UniCraft.Character.Profile.Attribute.Base;
using UnityEngine;

namespace UniCraft.Character.System
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to define a character system
	/// </summary>
	[DisallowMultipleComponent]
	public abstract class ACharacterSystem : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		[CustomHeader("Base Attribute")]
		[SerializeField] private LocomotionAttributeProfile _locomotionAttributes;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public LocomotionAttributeProfile LocomotionAttributes
		{
			get { return _locomotionAttributes; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		///////////////////////////////////////////////
		////////// ACharacterSystem Callback //////////

		/// <summary>
		/// Loads all the required components for the character system
		/// </summary>
		protected abstract void LoadComponents();
		
		////////////////////////////////////////////
		////////// MonoBehaviour Callback //////////

		protected virtual void Awake()
		{
			LoadComponents();
		}
	}
}
