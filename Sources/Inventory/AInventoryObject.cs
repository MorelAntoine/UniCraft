using UnityEngine;

namespace UniCraft.Inventory
{
	public abstract class AInventoryObject : ScriptableObject
	{
		////////////////////////////////
		////////// Attributes //////////

		////////// Basic information //////////
		
		[Header("Basic information")]
		[SerializeField] private string _name;
		[SerializeField, TextArea] private string _description;
		
		////////////////////////////////
		////////// Properties //////////
		
		////////// Basic information //////////

		public string Name
		{
			get { return _name; }
		}
		
		public string Description
		{
			get { return _description; }
		}
	}
}
