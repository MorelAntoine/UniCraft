using UnityEngine;
using UnityEngine.AI;

namespace UniCraft.Character.Behaviour
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to create a character behaviour driven by a NavMeshAgent
	/// </summary>
	[RequireComponent(typeof(NavMeshAgent))]
	public abstract class ADrivenCharacterBehaviour : ACharacterBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		private NavMeshAgent _navMeshAgent;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		public NavMeshAgent NavMeshAgent
		{
			get { return _navMeshAgent; }
		}

		////////////////////////////
		////////// Method //////////
		////////////////////////////

		//////////////////////////////////////////////////
		////////// ACharacterBehaviour Callback //////////

		protected override void Initialize()
		{
			_navMeshAgent.acceleration = 10f;
			_navMeshAgent.speed = 1f;
			_navMeshAgent.updateRotation = false;
		}

		////////////////////////////////////////////
		////////// MonoBehaviour Callback //////////
		
		protected override void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
			base.Awake();
		}

		protected override void Update()
		{
			base.Update();
			HandleNavMeshAgentStop();
		}
		
		/////////////////////////////
		////////// Service //////////

		private void HandleNavMeshAgentStop()
		{
			if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
				MotionInformation.Direction.Set(0f, 0f, 0f);
		}
	}
}
