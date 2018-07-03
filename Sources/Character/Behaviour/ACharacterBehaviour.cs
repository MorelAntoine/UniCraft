using UniCraft.Character.System.Core;
using UniCraft.Gamepad;
using UniCraft.Gamepad.Core;
using UnityEngine;

namespace UniCraft.Character.Behaviour
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(ACharacterSystem), typeof(GamepadSystem))]
	public abstract class ACharacterBehaviour : MonoBehaviour
	{
		////////////////////////////////
		////////// Attributes //////////

		private ACharacterSystem _characterSystem;
		private GamepadSystem _gamepadSystem;

		////////////////////////////////
		////////// Properties //////////

		protected GamepadConfiguration GamepadConfiguration
		{
			get { return _gamepadSystem.Configuration; }
		}

		protected GamepadInputInformation InputInfos
		{
			get { return _gamepadSystem.InputInfos; }
		}
		
		/////////////////////////////
		////////// Methods //////////

		////////// Callbacks //////////
		
		////////// ACharacterBehaviour
		
		protected abstract void Initialize();
		protected abstract void UpdateInputInfos();
		
		////////// MonoBehaviour
		
		private void Awake()
		{
			LoadComponents();
			Initialize();
		}
		
		private void FixedUpdate()
		{
			_characterSystem.UpdateMotionStateMachine(InputInfos);
		}

		private void Update()
		{
			UpdateInputInfos();
		}
		
		////////// Services //////////

		private void LoadComponents()
		{
			_characterSystem = GetComponent<ACharacterSystem>();
			_gamepadSystem = GetComponent<GamepadSystem>();
		}
	}
}
