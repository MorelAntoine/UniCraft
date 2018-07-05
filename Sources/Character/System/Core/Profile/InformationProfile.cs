using UnityEngine;

namespace UniCraft.Character.System.Core.Profile
{
	[global::System.Serializable]
	public sealed class InformationProfile
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		//////////////////////////////////////////
		////////// Personal information //////////

		[Header("Personal information")]
		[SerializeField] private string _firstName;
		[SerializeField] private string _lastName;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		//////////////////////////////////////////
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
