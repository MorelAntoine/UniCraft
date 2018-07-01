﻿using System.Collections.Generic;
using UnityEngine;

namespace UniCraft.Inventory
{
	[DisallowMultipleComponent]
	public class InventorySystem : MonoBehaviour
	{
		////////////////////////////////
		////////// Attributes //////////
		
		////////// Information //////////

		[Header("Information")]
		[SerializeField] private List<AInventoryObject> _inventoryObjects;
		
		////////// Settings //////////

		[Header("Settings")]
		[SerializeField] private int _inventoryMaxSize = 10;

		////////////////////////////////
		////////// Properties //////////

		////////// Information //////////

		public IEnumerable<AInventoryObject> InventoryObjects
		{
			get { return _inventoryObjects; }
		}
		
		public int InventoryObjectCount
		{
			get { return _inventoryObjects.Count; }
		}
		
		public int InventoryObjectCountRemaining
		{
			get { return Mathf.Clamp(_inventoryMaxSize - _inventoryObjects.Count, 0, _inventoryMaxSize); }
		}

		////////// Settings //////////

		public int InventoryMaxSize
		{
			get { return _inventoryMaxSize; }
			set { _inventoryMaxSize = value; }
		}

		/////////////////////////////
		////////// Methods //////////
		
		////////// Information //////////

		public bool InventoryContain(AInventoryObject inventoryObject)
		{
			return (_inventoryObjects.Contains(inventoryObject));
		}
		
		public bool InventoryContainByName(string inventoryObjectName)
		{
			return (_inventoryObjects.Find(io => io.Name == inventoryObjectName) != null);
		}
		
		////////// Management //////////

		public void AddInventoryObject(AInventoryObject inventoryObject)
		{
			_inventoryObjects.Add(inventoryObject);
		}

		public void ClearInventory()
		{
			_inventoryObjects.Clear();
		}
		
		public void RemoveInventoryObject(AInventoryObject inventoryObject)
		{
			_inventoryObjects.Remove(inventoryObject);
		}
		
		public void RemoveInventoryObjectByName(string inventoryObjectName)
		{
			_inventoryObjects.Remove(_inventoryObjects.Find(io => io.Name == inventoryObjectName));
		}
		
		////////// Predicates //////////

		public IEnumerable<AInventoryObject> FindInventoryObjectsByContainDescription(string matchDescription)
		{
			return (_inventoryObjects.FindAll(io => io.Description.Contains(matchDescription)));
		}
		
		public IEnumerable<AInventoryObject> FindInventoryObjectsByContainName(string matchName)
		{
			return (_inventoryObjects.FindAll(io => io.Name.Contains(matchName)));
		}
		
		////////// Sorts //////////

		public void SortInventoryByName()
		{
			_inventoryObjects.Sort();
		}
		
		public void InverseSortInventoryByName()
		{
			_inventoryObjects.Sort();
			_inventoryObjects.Reverse();
		}
	}
}
