using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameEnterState : IGameState
    {
        private GameStateMachine _stateMachine;

        public GameEnterState(AllServices services, GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }

        public void Enter()
        {
            // Display horse selection
        }

        public void Exit()
        {
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