using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class PlayerInputRotatorState : State, IUpdatableState
    {
        private IInputService _inputService;
        private ReactiveVariable<Vector3> _rotationDirection;
        private Transform _transform;

        public PlayerInputRotatorState(
            Entity entity,
            IInputService inputService)
        {
            _inputService = inputService;
            _rotationDirection = entity.RotationDirection;
            
            _transform = entity.Transform;
        }

        public void Update(float deltaTime)
        {
            _rotationDirection.Value = _inputService.MouseDirection;
        }

        public override void Exit()
        {
            base.Exit();

            _rotationDirection.Value = Vector3.zero;
        }
    }
}