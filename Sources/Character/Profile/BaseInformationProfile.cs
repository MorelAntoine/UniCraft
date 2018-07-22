using UnityEngine;

namespace UniCraft.Character.Profile
{
	/// <summary>
	/// Profile class used to contains all the primary information of a character
	/// </summary>
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
			set { _name = value; }
		}
	}
}
