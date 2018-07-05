using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Toolbox.Component.GamepadSystem
{
	[AddComponentMenu("UniCraft/Toolbox/GamepadSystem")]
	[DisallowMultipleComponent]
	public sealed class GamepadSystem : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////
		
		/////////////////////////////////
		////////// Information //////////

		[Header("Information")]
		[SerializeField] private GamepadInputInformation _inputInformation;
		
		/////////////////////////////
		////////// Setting //////////

		[Header("Setting")]
		[SerializeField] private GamepadConfiguration _configuration;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		/////////////////////////////////
		////////// Information //////////

		public GamepadInputInformation InputInformation
		{
			get { return _inputInformation; }
		}

		/////////////////////////////
		////////// Setting //////////

		public GamepadConfiguration Configuration
		{
			get { return _configuration; }
		}
	}
}
