using UniCraft.Inventory.System;
using UnityEngine;
using UnityEngine.Events;

namespace UniCraft.Inventory.GUI
{
	[DisallowMultipleComponent]
	public abstract class AInventoryGuiSystem : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		///////////////////////////////
		////////// GUI event //////////

		[Header("GUI event")]
		[SerializeField] private UnityEvent _onInventoryGuiOpen;
		[SerializeField] private UnityEvent _onInventoryGuiClose;

		/////////////////////////////
		////////// Setting //////////

		[Header("Setting")]
		[SerializeField] private GameObject _inventoryGui;
		[SerializeField] private InventorySystem _inventorySystem;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////
		
		///////////////////////////////
		////////// GUI event //////////

		public UnityEvent OnInventoryGuiClose
		{
			get { return _onInventoryGuiClose; }
		}

		public UnityEvent OnInventoryGuiOpen
		{
			get { return _onInventoryGuiOpen; }
		}

		/////////////////////////////////
		////////// Information //////////

		public bool IsInventoryGuiOpen
		{
			get { return _inventoryGui.activeInHierarchy; }
		}
		
		/////////////////////////////
		////////// Setting //////////

		public GameObject InventoryGui
		{
			get { return _inventoryGui; }
			set { _inventoryGui = value; }
		}

		public InventorySystem InventorySystem
		{
			get { return _inventorySystem; }
			set { _inventorySystem = value; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public void CloseInventoryGui()
		{
			_inventoryGui.SetActive(false);
			_onInventoryGuiClose.Invoke();
		}

		public void OpenInventoryGui()
		{
			_inventoryGui.SetActive(true);
			_onInventoryGuiOpen.Invoke();
		}
	}
}
