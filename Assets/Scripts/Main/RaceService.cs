using Assets.Scripts.Infrastructure;
using Assets.Scripts.Objects;
using Assets.Scripts.UI;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public interface IRaceService : IService
    {
        public void InitializeRace();

        public void StartRace();

        public void OnHorseFinish(Horse horse);

        public List<Horse> Horses { get; set; }

        public Horse SelectedHorse { get; set; }
    }

    public class RaceService : MonoBehaviour, IRaceService
    {
        public Engine Engine;

        public GameResultsComponent GameResultsComponent;

        public Horse SelectedHorse { get; set; }

        public List<Horse> Horses { get; set; }

        public Queue<Horse> ResultsQueue { get; private set; } = new();

        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private List<Transform> _endingPoints;
        [SerializeField] private GameObject _horsePrefab;
        [SerializeField] private List<Material> _horseMaterials;
        [SerializeField] private List<Sprite> _horseImages;

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
                var image = _horseImages[i];
                var horse = Instantiate(_horsePrefab, spawnPoint, Quaternion.identity).GetComponent<Horse>();
                horse.RaceService = this;
                horse.Initialize(endingPoint, spawnPoint, name, material, image);
                Horses.Add(horse);
            }
        }

        public void SetHorseBet(Horse horse)
        {
            SelectedHorse = horse;
        }

        public void StartRace()
        {
            foreach (var horse in Horses)
                horse.Activate();
        }

        public void OnHorseFinish(Horse horse)
        {
            horse.Deactivate();
            if (horse == SelectedHorse)
                Engine.EndGame();

            ResultsQueue.Enqueue(horse);
            GameResultsComponent.RefreshResultTable();
        }
    }
}