using UniCraft.Character.Mechanism.System.Motion.Information.Configuration;
using UniCraft.Character.Mechanism.System.Motion.Information.Input;

namespace UniCraft.Character.Mechanism.System.Motion.Information
{
	/// <summary>
	/// Information class containing all the motion information to run the motion state machine
	/// </summary>
	[global::System.Serializable]
	public class MotionInformation
	{
		public MotionConfiguration Configuration;
		public MotionInput Input;
	}
}
