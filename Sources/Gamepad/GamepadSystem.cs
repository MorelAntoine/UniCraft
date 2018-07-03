using UniCraft.Gamepad.Core;
using UnityEngine;

namespace UniCraft.Gamepad
{
	[AddComponentMenu("UniCraft/GamepadSystem")]
	[DisallowMultipleComponent]
	public sealed class GamepadSystem : MonoBehaviour
	{
		////////////////////////////////
		////////// Attributes //////////
		
		////////// Information //////////

		[Header("Information")]
		[SerializeField] private GamepadInputInformation _inputInformation;
		
		////////// Settings //////////

		[Header("Settings")]
		[SerializeField] private GamepadConfiguration _configuration;

		////////////////////////////////
		////////// Properties //////////

		////////// Information //////////

		public GamepadInputInformation InputInfos
		{
			get { return _inputInformation; }
		}

		////////// Settings //////////

		public GamepadConfiguration Configuration
		{
			get { return _configuration; }
		}
	}
}
