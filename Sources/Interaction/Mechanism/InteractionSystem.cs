using UnityEngine;
using UnityEngine.Events;

namespace UniCraft.Interaction.Mechanism
{
	/// <inheritdoc/>
	/// <summary>
	/// System class holding the core interaction mechanism
	/// </summary>
	public class InteractionSystem : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		[SerializeField] private string _interactionName;
		[SerializeField] private string _triggerButtonName;
		[SerializeField] private UnityEvent _onInteractionEvents;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public string InteractionName
		{
			get { return _interactionName; }
		}

		public string TriggerButtonName
		{
			get { return _triggerButtonName; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		/// <summary>
		/// Verify if the interaction can be trigged
		/// </summary>
		public bool CanBeTrigged()
		{
			return (Input.GetButtonDown(_triggerButtonName));
		}
		
		/// <summary>
		/// Trigger the interaction events
		/// </summary>
		public void Interact()
		{
			_onInteractionEvents.Invoke();
		}
	}
}
