using Assets.Scripts.Infrastructure;
using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public interface IRaceService : IService
    {
        public void InitializeRace();

        public void StartRace();

        public void EndRace();

        public Horse SelectedHorse { get; set; }
    }

    public class RaceService : MonoBehaviour, IRaceService
    {
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private List<Transform> _endingPoints;
        [SerializeField] private GameObject _horsePrefab;

        public Horse SelectedHorse { get; set; }

        public void InitializeRace()
        {
            for (int i = 0; i < 5; i++)
            {
                var spawnPoint = _spawnPoints[i].position;
                var endingPoint = _endingPoints[i].position;
                var horse = Instantiate(_horsePrefab, spawnPoint, Quaternion.identity).GetComponent<Horse>();
                horse.Initialize(endingPoint, spawnPoint);
                horse.Activate();
                SelectedHorse = horse;
            }
            // Spawn horses, randomize their stats
        }

        public void StartRace()
        {

        }

        public void EndRace()
        {

        }
    }
}