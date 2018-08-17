using UniCraft.Character.Mechanism.Behaviour;
using UniCraft.Character.Mechanism.System.Motion.Information.Input;
using UnityEngine;

namespace UniCraft.Character.Kit.Behaviour.AI.Basic
{
    public class CharacterFollowerBehaviour : ANavCharacterBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        public Transform Target;
        private Vector3 _previousTargetPosition = Vector3.zero;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        /////////////////////////////////////////////////////
        ////////// ANavCharacterBehaviour Callback //////////
        
        protected override void Initialize()
        {
            UpdateTargetTracking();
        }

        protected override void UpdateMotionInput(ref MotionInput mi)
        {
            if (_previousTargetPosition != Target.position)
                UpdateTargetTracking();
            mi.MovementDirection = NextDirection;
        }
        
        /////////////////////////////
        ////////// Service //////////

        private void UpdateTargetTracking()
        {
            _previousTargetPosition = Target.position;
            Destination = Target.position;
        }
    }
}
