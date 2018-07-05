﻿using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.State.Locomotion
{
	[CreateAssetMenu(menuName = "UniCraft/Character/State/Locomotion/CrouchWalk")]
	public class CrouchWalk : AMotionState
	{
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		public override void Move(CharacterSystem cs, GamepadInputInformation inputInformation)
		{
			cs.transform.Rotate(0f, inputInformation.MotionHorizontalAxisValue * cs.Attributes.TurnSpeed * Time.deltaTime, 0f);
			cs.transform.Translate(0f, 0f, inputInformation.MotionVerticalAxisValue * cs.Attributes.CrouchSpeed * Time.deltaTime, Space.Self);
		}

		public override void Move2D(CharacterSystem2D cs2D, GamepadInputInformation inputInformation)
		{
			cs2D.transform.Translate(inputInformation.MotionHorizontalAxisValue * cs2D.Attributes.CrouchSpeed * Time.deltaTime, 0f, 0f);
		}
	}
}
