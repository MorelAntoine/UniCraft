﻿using UniCraft.Gamepad.Core;
using UnityEngine;

namespace UniCraft.Character.System.Core.Motion.State.Locomotion
{
	[CreateAssetMenu(menuName = "UniCraft/Character/State/Locomotion/Walk")]
	public class Walk : AMotionState
	{
		public override void Move(CharacterSystem cs, GamepadInputInformation inputInfos)
		{
			cs.transform.Rotate(0f, inputInfos.MotionHorizontalAxisValue * cs.Attributes.TurnSpeed * Time.deltaTime, 0f);
			cs.transform.Translate(0f, 0f, inputInfos.MotionVerticalAxisValue * cs.Attributes.WalkSpeed * Time.deltaTime, Space.Self);
		}

		public override void Move2D(CharacterSystem2D cs2D, GamepadInputInformation inputInfos)
		{
			cs2D.transform.Translate(inputInfos.MotionHorizontalAxisValue * cs2D.Attributes.WalkSpeed * Time.deltaTime, 0f, 0f);
		}
	}
}
