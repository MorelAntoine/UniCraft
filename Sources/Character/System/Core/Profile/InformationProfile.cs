using UnityEngine;

namespace UniCraft.Character.System.Core.Profile
{
	/// <inheritdoc/>
	/// <summary>
	/// Component class used by ACharacterSystem to hold information about a character
	/// </summary>
	[DisallowMultipleComponent]
	public class InformationProfile : MonoBehaviour
	{
		////////////////////////////////
		////////// Attributes //////////
		
		////////// Personal information //////////

		[Header("Personal information")]
		[SerializeField] private string _firstName;
		[SerializeField] private string _lastName;

		////////////////////////////////
		////////// Properties //////////

		////////// Personal information //////////

		public string FirstName
		{
			get { return _firstName; }
		}

		public string LastName
		{
			get { return _lastName; }
		}
	}
}
