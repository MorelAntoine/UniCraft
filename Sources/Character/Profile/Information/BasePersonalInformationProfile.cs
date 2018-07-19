using UnityEngine;

namespace UniCraft.Character.Profile.Information
{
	[global::System.Serializable]
	public class BaseInformationProfile
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
