using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public interface IRaceService : IService
    {
        public void StartRace();

        public void EndRace();
    }

    public class RaceService : MonoBehaviour, IRaceService
    {
        public void EndRace()
        {

        }

        public void StartRace()
        {

        }
    }
}