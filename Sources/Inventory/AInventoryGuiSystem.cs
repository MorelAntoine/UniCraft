using UnityEngine;
using UnityEngine.Events;

namespace UniCraft.Inventory
{
	[DisallowMultipleComponent]
	public abstract class AInventoryGuiSystem : MonoBehaviour
	{
		////////////////////////////////
		////////// Attributes //////////
		
		////////// GUI events //////////

		[Header("GUI events")]
		[SerializeField] private UnityEvent _onInventoryGuiOpen;
		[SerializeField] private UnityEvent _onInventoryGuiClose;

		////////// Settings //////////

		[Header("Settings")]
		[SerializeField] private GameObject _inventoryGui;
		[SerializeField] private InventorySystem _inventorySystem;
		
		////////////////////////////////
		////////// Attributes //////////
		
		////////// GUI events //////////

		public UnityEvent OnInventoryGuiClose
		{
			get { return _onInventoryGuiClose; }
		}

		public UnityEvent OnInventoryGuiOpen
		{
			get { return _onInventoryGuiOpen; }
		}

		////////// Information //////////

		public bool IsInventoryGuiOpen
		{
			get { return _inventoryGui.activeInHierarchy; }
		}
		
		////////// Settings //////////

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

		/////////////////////////////
		////////// Methods //////////
		
		////////// Management //////////

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
