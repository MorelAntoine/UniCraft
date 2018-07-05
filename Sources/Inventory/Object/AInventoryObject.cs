using UnityEngine;

namespace UniCraft.Inventory.Object
{
	public abstract class AInventoryObject : ScriptableObject
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		[SerializeField] private string _name;
		[SerializeField, TextArea] private string _description;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public string Description
		{
			get { return _description; }
		}
		
		public string Name
		{
			get { return _name; }
		}
	}
}
