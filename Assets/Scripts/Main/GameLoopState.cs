using Assets.Scripts.Infrastructure;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameLoopState : IGameState
    {
        private GameStateMachine _stateMachine;

        private ICameraService _cameraService;

        private IUIComponentsService _uiComponentsService;

        private IRaceService _raceService;

        public GameLoopState(AllServices services, GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
            _cameraService = services.Single<ICameraService>();
            _raceService = services.Single<IRaceService>();
            _uiComponentsService = services.Single<IUIComponentsService>();
        }

        public void Enter()
        {
            _raceService.StartRace();
            _cameraService.SetCameraFollowing(_raceService.SelectedHorse.CameraFollowPoint);
            _uiComponentsService.DrawRacePanel();
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