using UniCraft.Character.Profile.Attribute.Base;
using UniCraft.Character.Profile.Information.Base;
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

		[SerializeField] private BaseLocomotionAttributeProfile _baseLocomotionAttribute;
		[SerializeField] private BasePersonalInformationProfile _basePersonalInformation;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public BaseLocomotionAttributeProfile BaseLocomotionAttribute
		{
			get { return _baseLocomotionAttribute; }
		}

		public BasePersonalInformationProfile BasePersonalInformation
		{
			get { return _basePersonalInformation; }
		}
	}
}
