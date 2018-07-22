using UniCraft.Attribute;
using UniCraft.Character.Profile.Attribute;
using UniCraft.Character.Profile.Information;
using UnityEngine;

namespace UniCraft.Character.System
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to create a character system
	/// </summary>
	[DisallowMultipleComponent]
	public abstract class ACharacterSystem : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		//////////////////////////////////
		////////// Base Profile //////////
		
		[CustomHeader("Base Profile")]
		[SerializeField] private BaseInformationProfile _baseInformation;
		[SerializeField] private LocomotionAttributeProfile _locomotionAttribute;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public BaseInformationProfile BaseInformation
		{
			get { return _baseInformation; }
		}

		public LocomotionAttributeProfile LocomotionAttribute
		{
			get { return _locomotionAttribute; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		protected virtual void Awake()
		{
			LoadComponents();
		}

		/// <summary>
		/// Callback to load all the required components for the character system
		/// </summary>
		protected abstract void LoadComponents();
	}
}
