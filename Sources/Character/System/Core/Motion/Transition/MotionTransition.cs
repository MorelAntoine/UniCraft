using System.Linq;
using UniCraft.Character.System.Core.Motion.Condition;
using UniCraft.Character.System.Core.Motion.State;
using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.Transition
{
	[CreateAssetMenu(menuName = "UniCraft/Character/Transition")]
	public class MotionTransition : ScriptableObject
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		/////////////////////////////
		////////// Setting //////////
		
		[Header("Setting")]
		[SerializeField] private AMotionCondition[] _conditions;
		
		////////// Motion state //////////
		
		[Header("Motion state")]
		[SerializeField] private AMotionState _stateOnSuccess;
		[SerializeField] private AMotionState _stateOnFailure;
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////

		public AMotionState GetNextState(CharacterSystem cs, GamepadInputInformation inputInfos)
		{
			return (_conditions.All(c => c.IsComplete(cs, inputInfos)) ? _stateOnSuccess : _stateOnFailure);
		}

		public AMotionState GetNextState2D(CharacterSystem2D cs2D, GamepadInputInformation inputInfos)
		{
			return (_conditions.All(c => c.IsComplete2D(cs2D, inputInfos)) ? _stateOnSuccess : _stateOnFailure);
		}
	}
}
