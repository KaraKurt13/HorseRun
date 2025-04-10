using Assets.Scripts.Infrastructure;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameEndingState : IGameState
    {
        private IUIComponentsService _uiComponentsService;

        public GameEndingState(AllServices services)
        {
            _uiComponentsService = services.Single<IUIComponentsService>();
        }

        public void Enter()
        {
            _uiComponentsService.DrawResultScreen();
        }

        public void Exit()
        {
            _uiComponentsService.HideResultScreen();
        }

        public void PhysicsUpdate()
        {
        }

        public void Update()
        {
        }
    }
}