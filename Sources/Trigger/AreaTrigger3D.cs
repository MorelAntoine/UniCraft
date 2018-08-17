using UniCraft.Toolbox.UnityEvent;
using UnityEngine;

namespace UniCraft.Trigger
{
	/// <inheritdoc />
	/// <summary>
	/// Component class used to bind 3D events to the trigger area
	/// </summary>
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Collider))]
	public class AreaTrigger3D : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		[SerializeField] private UnityEventCollider _onTriggerEnterEvents;
		[SerializeField] private UnityEventCollider _onTriggerStayEvents;
		[SerializeField] private UnityEventCollider _onTriggerExitEvents;

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		private void OnTriggerEnter(Collider other)
		{
			_onTriggerEnterEvents.Invoke(other);
		}

		private void OnTriggerStay(Collider other)
		{
			_onTriggerStayEvents.Invoke(other);
		}

		private void OnTriggerExit(Collider other)
		{
			_onTriggerExitEvents.Invoke(other);
		}
	}
}
