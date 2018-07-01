using UniCraft.Character.System.Core;
using UniCraft.Gamepad;
using UniCraft.Gamepad.Core;
using UnityEngine;

namespace UniCraft.Character.Behaviour
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(ACharacterSystem))]
	public abstract class ACharacterBehaviour : MonoBehaviour
	{
		////////////////////////////////
		////////// Attributes //////////

		private ACharacterSystem _characterSystem;
		[SerializeField] private GamepadSystem _gamepadSystem;

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

		////////// Character Behaviour callbacks //////////

		protected abstract void Initialize();
		
		protected abstract void UpdateInputInfos();
		
		////////// MonoBehaviour callbacks //////////
		
		private void Awake()
		{
			_characterSystem = GetComponent<ACharacterSystem>();
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
	}
}
