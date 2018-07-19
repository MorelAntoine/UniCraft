using UnityEngine;

namespace UniCraft.Character.Behaviour.Player
{
	public class PlayerBehaviour : ACharacterBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		[SerializeField] private string _horizontalAxisName = "Horizontal";
		[SerializeField] private string _verticalAxisName = "Vertical";
		[SerializeField] private bool _useRawAxisInput = true;
		[SerializeField] private bool _useVerticalAxis = true;
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////
		
		//////////////////////////////////////////////////
		////////// ACharacterBehaviour Callback //////////
		
		protected override void Initialize()
		{}

		protected override void UpdateMotionInformation()
		{
			UpdateMovementDirection();
		}
		
		/////////////////////////////
		////////// Service //////////

		private void UpdateMovementDirection()
		{
			if (_useRawAxisInput)
			{
				MotionInformation.MovementDirection.x = Input.GetAxisRaw(_horizontalAxisName);
				if (_useVerticalAxis)
					MotionInformation.MovementDirection.z = Input.GetAxisRaw(_verticalAxisName);
			}
			else
			{
				MotionInformation.MovementDirection.x = Input.GetAxis(_horizontalAxisName);
				if (_useVerticalAxis)
					MotionInformation.MovementDirection.z = Input.GetAxis(_verticalAxisName);
			}
		}
	}
}
