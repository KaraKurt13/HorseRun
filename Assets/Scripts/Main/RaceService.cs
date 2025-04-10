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

        public List<Horse> Horses { get; set; }

        public Horse SelectedHorse { get; set; }
    }

    public class RaceService : MonoBehaviour, IRaceService
    {
        public Horse SelectedHorse { get; set; }

        public List<Horse> Horses { get; set; }

        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private List<Transform> _endingPoints;
        [SerializeField] private GameObject _horsePrefab;
        [SerializeField] private List<Material> _horseMaterials;

        private readonly List<string> _horseNames = new List<string>() 
        {
            "Dust Runner",
            "Stormhoof",
            "Velvet Blaze",
            "Iron Comet",
            "Shadowstride"
        };

        public void InitializeRace()
        {
            Horses = new();
            for (int i = 0; i < 5; i++)
            {
                var spawnPoint = _spawnPoints[i].position;
                var endingPoint = _endingPoints[i].position;
                var name = _horseNames[i];
                var material = _horseMaterials[i];
                var horse = Instantiate(_horsePrefab, spawnPoint, Quaternion.identity).GetComponent<Horse>();
                horse.Initialize(endingPoint, spawnPoint, name, material);
                horse.Activate();
                SelectedHorse = horse;
                Horses.Add(horse);
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