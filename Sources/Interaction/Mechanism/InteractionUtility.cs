using System.Collections.Generic;
using UnityEngine;

namespace UniCraft.Interaction.Mechanism
{
	/// <summary>
	/// Utility class to facilitate the handling of the Interaction System
	/// </summary>
	public static class InteractionUtility
	{
		/// <summary>
		/// Attempt to trigger the first possible interaction
		/// </summary>
		public static void AttemptToInteract(IEnumerable<InteractionSystem> interactionSystems)
		{
			foreach (var interaction in interactionSystems)
			{
				if (interaction.CanBeTrigged() == false) continue;
				interaction.Interact();
				break;
			}
		}
		
		public static IEnumerable<InteractionSystem> GetAllInteractionSystems(GameObject gameObject)
		{
			return (gameObject.GetComponents<InteractionSystem>());
		}
		
		public static bool IsInteractable(GameObject gameObject)
		{
			return (gameObject.GetComponent<InteractionSystem>() != null);
		}
	}
}
