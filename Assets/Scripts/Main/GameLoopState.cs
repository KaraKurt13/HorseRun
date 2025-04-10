using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameLoopState : IGameState
    {
        private GameStateMachine _stateMachine;

        private ICameraService _cameraService;

        private IRaceService _raceService;

        public GameLoopState(AllServices services, GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
            _cameraService = services.Single<ICameraService>();
            _raceService = services.Single<IRaceService>();
        }

        public void Enter()
        {
            _cameraService.SetCameraFollowing(_raceService.SelectedHorse.CameraFollowPoint);
        }

        public void Exit()
        {
        }

        public void PhysicsUpdate()
        {
        }

        public void Update()
        {
            // Update horses run progression
        }
    }
}