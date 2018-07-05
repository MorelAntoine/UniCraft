using UniCraft.Character.System.Core;
using UniCraft.Toolbox.Component.GamepadSystem;
using UniCraft.Toolbox.Component.GamepadSystem.Core;
using UnityEngine;

namespace UniCraft.Character.Behaviour
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(ACharacterSystem), typeof(GamepadSystem))]
	public abstract class ACharacterBehaviour : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		private ACharacterSystem _characterSystem;
		private GamepadSystem _gamepadSystem;

		//////////////////////////////
		////////// Property //////////
		//////////////////////////////

		protected GamepadConfiguration GamepadConfiguration
		{
			get { return _gamepadSystem.Configuration; }
		}

		protected GamepadInputInformation InputInformation
		{
			get { return _gamepadSystem.InputInformation; }
		}
		
		////////////////////////////
		////////// Method //////////
		////////////////////////////

		/////////////////////////////////////////////////
		////////// ACharacterBehaviour callback /////////
		
		protected abstract void Initialize();
		protected abstract void UpdateInputInformation();
		
		///////////////////////////////////////////
		////////// MonoBehaviour callback /////////
		
		private void Awake()
		{
			_characterSystem = GetComponent<ACharacterSystem>();
			_gamepadSystem = GetComponent<GamepadSystem>();
			Initialize();
		}
		
		private void FixedUpdate()
		{
			_characterSystem.UpdateMotionStateMachine(_gamepadSystem.InputInformation);
		}

		private void Update()
		{
			UpdateInputInformation();
		}
	}
}
