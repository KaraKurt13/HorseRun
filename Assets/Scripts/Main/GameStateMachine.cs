using Assets.Scripts.Infrastructure;
using Assets.Scripts.Main.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameStateMachine : BaseStateMachine<IGameState>
    {
        public GameStateMachine(AllServices services, Engine engine)
        {

        }
    }
}