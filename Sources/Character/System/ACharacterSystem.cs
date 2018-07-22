using UniCraft.Attribute;
using UniCraft.Character.Profile;
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

		[CustomHeader("Base Profile")]
		[SerializeField] private BaseInformationProfile _baseInformationProfile;
		[SerializeField] private BaseLocomotionProfile _baseLocomotionProfile;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public BaseInformationProfile BaseInformationProfile
		{
			get { return _baseInformationProfile; }
		}

		public BaseLocomotionProfile BaseLocomotionProfile
		{
			get { return _baseLocomotionProfile; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		///////////////////////////////////////////////
		////////// ACharacterSystem Callback //////////

		/// <summary>
		/// Callback used to load all the components of the character system
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
