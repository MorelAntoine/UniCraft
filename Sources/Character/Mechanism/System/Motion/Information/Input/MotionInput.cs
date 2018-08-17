using UnityEngine;

namespace UniCraft.Character.Mechanism.System.Motion.Information.Input
{
	/// <summary>
	/// Information class containing all the motion input information
	/// </summary>
	[global::System.Serializable]
	public class MotionInput
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		public Vector3 MovementDirection;
		public bool Crouch;
		public bool Jump;
		public bool Run;
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////

		/// <summary>
		/// Reset the input values
		/// </summary>
		public void Reset()
		{
			MovementDirection.Set(0f, 0f, 0f);
			Crouch = false;
			Jump = false;
			Run = false;
		}
	}
}
