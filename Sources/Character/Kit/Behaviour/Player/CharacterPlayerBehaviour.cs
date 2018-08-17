using UniCraft.Character.Mechanism.Behaviour;
using UniCraft.Character.Mechanism.System.Motion.Information.Input;
using UnityEngine;

namespace UniCraft.Character.Kit.Behaviour.Player
{
    /// <inheritdoc/>
    /// <summary>
    /// Component class defining a basic character player behaviour
    /// </summary>
    public class CharacterPlayerBehaviour : ACharacterBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private KeyCode _crouchKeyCode = KeyCode.C;
        [SerializeField] private KeyCode _runKeyCode = KeyCode.R;
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
        {
        }

        protected override void UpdateMotionInput(ref MotionInput mi)
        {
            UpdateAxis(ref mi);
            UpdateKeyCode(ref mi);
        }
        
        /////////////////////////////
        ////////// Service //////////

        private void UpdateAxis(ref MotionInput mi)
        {
            if (_useRawAxisInput)
            {
                mi.MovementDirection.x = Input.GetAxisRaw(_horizontalAxisName);
                if (_useVerticalAxis)
                    mi.MovementDirection.z = Input.GetAxisRaw(_verticalAxisName);
            }
            else
            {
                mi.MovementDirection.x = Input.GetAxis(_horizontalAxisName);
                if (_useVerticalAxis)
                    mi.MovementDirection.z = Input.GetAxis(_verticalAxisName);
            }
        }

        private void UpdateKeyCode(ref MotionInput mi)
        {
            mi.Crouch = Input.GetKey(_crouchKeyCode);
            mi.Run = Input.GetKey(_runKeyCode);
        }
    }
}
