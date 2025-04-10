using Assets.Scripts.Infrastructure;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameEnterState : IGameState
    {
        private GameStateMachine _stateMachine;

        private IUIComponentsService _uiComponentsService;
        private IRaceService _raceService;

        public GameEnterState(AllServices services, GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
            _uiComponentsService = services.Single<IUIComponentsService>();
            _raceService = services.Single<IRaceService>();
        }

        public void Enter()
        {
            _raceService.InitializeRace();
            _uiComponentsService.DrawBetPanel();
            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            _uiComponentsService.HideBetPanel();
            // Hide horse selection
            // Draw main game UI (horse run progression)
            // Set camera to follow selected horse
        }

        public void PhysicsUpdate()
        {
        }

        public void Update()
        {
        }
    }
}