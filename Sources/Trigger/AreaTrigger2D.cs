using UniCraft.Toolbox.UnityEvent;
using UnityEngine;

namespace UniCraft.Trigger
{
    /// <inheritdoc/>
    /// <summary>
    /// Component class used to bind 2D events to the trigger area
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider2D))]
    public class AreaTrigger2D : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private UnityEventCollider2D _onTriggerEnterEvents;
        [SerializeField] private UnityEventCollider2D _onTriggerStayEvents;
        [SerializeField] private UnityEventCollider2D _onTriggerExitEvents;

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        private void OnTriggerEnter2D(Collider2D other)
        {
            _onTriggerEnterEvents.Invoke(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            _onTriggerStayEvents.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _onTriggerExitEvents.Invoke(other);
        }
    }
}
