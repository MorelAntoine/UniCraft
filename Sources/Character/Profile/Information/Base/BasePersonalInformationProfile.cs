using UnityEngine;

namespace UniCraft.Character.Profile.Information.Base
{
	[global::System.Serializable]
	public class BasePersonalInformationProfile
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		[SerializeField] private string _name;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public string Name
		{
			get { return _name; }
		}
	}
}
