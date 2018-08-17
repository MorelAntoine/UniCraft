using UniCraft.Character.Mechanism.System.Motion.Information.Configuration;
using UnityEngine;
using UnityEngine.AI;

namespace UniCraft.Character.Mechanism.Behaviour
{
	/// <inheritdoc/>
	/// <summary>
	/// Base class to create a character behaviour that use a NavMeshAgent
	/// </summary>
	[RequireComponent(typeof(NavMeshAgent))]
	public abstract class ANavCharacterBehaviour : ACharacterBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		private NavMeshAgent _navMeshAgent;
		
		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		protected Vector3 Destination
		{
			get { return _navMeshAgent.destination; }
			set { _navMeshAgent.SetDestination(value); }
		}

		protected bool IsArrived
		{
			get { return _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance; }
		}
		
		protected Vector3 NextDirection
		{
			get { return _navMeshAgent.desiredVelocity.normalized; }
		}

		protected NavMeshPath Path
		{
			get { return _navMeshAgent.path; }
			set { _navMeshAgent.SetPath(value); }
		}

		protected float Radius
		{
			get { return _navMeshAgent.radius; }
			set { _navMeshAgent.radius = value; }
		}
		
		protected float RemainingDistance
		{
			get { return _navMeshAgent.remainingDistance; }
		}
		
		protected float StoppingDistance
		{
			get { return _navMeshAgent.stoppingDistance; }
			set { _navMeshAgent.stoppingDistance = value; }
		}
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		///////////////////////////////
		////////// Mechanism //////////

		protected override void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
			InitializeNavMeshAgent();
			base.Awake();
		}

		private void InitializeNavMeshAgent()
		{
			_navMeshAgent.acceleration = 8f;
			_navMeshAgent.speed = 1f;
			if (_navMeshAgent.stoppingDistance < 0.1f) _navMeshAgent.stoppingDistance = 1.2f;
			_navMeshAgent.updatePosition = true;
			_navMeshAgent.updateRotation = false;
		}
		
		protected override void SetupMotionConfiguration(ref MotionConfiguration mc)
		{
			base.SetupMotionConfiguration(ref mc);
			mc.ShouldAdaptToNavMesh = true;
		}

		//////////////////////////////////////////
		////////// NavMeshAgent Service //////////

		/// <summary>
		/// Calculate a path to a specified point and store the resulting path
		/// </summary>
		protected bool CalculatePath(Vector3 targetPosition, NavMeshPath path)
		{
			return (_navMeshAgent.CalculatePath(targetPosition, path));
		}
	}
}
