using System.Linq;
using UniCraft.Character.System.Core.Motion.Condition;
using UniCraft.Character.System.Core.Motion.State;
using UniCraft.Gamepad.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.Transition
{
	[CreateAssetMenu(menuName = "UniCraft/Character/Transition")]
	public class MotionTransition : ScriptableObject
	{
		////////////////////////////////
		////////// Attributes //////////

		[SerializeField] private AMotionCondition[] _conditions;
		
		////////// Motion states //////////

		[Header("Motion states")]
		[SerializeField] private AMotionState _onSuccesState;
		[SerializeField] private AMotionState _onFailureState;
		
		/////////////////////////////
		////////// Methods //////////

		public AMotionState GetNextState(CharacterSystem cs, GamepadInputInformation inputInfos)
		{
			return (_conditions.All(c => c.IsComplete(cs, inputInfos)) ? _onSuccesState : _onFailureState);
		}

		public AMotionState GetNextState2D(CharacterSystem2D cs2D, GamepadInputInformation inputInfos)
		{
			return (_conditions.All(c => c.IsComplete2D(cs2D, inputInfos)) ? _onSuccesState : _onFailureState);
		}
	}
}
