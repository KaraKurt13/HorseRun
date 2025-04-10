using Assets.Scripts.Main;
using Assets.Scripts.UI.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class RacePanelComponent : ComponentBase
    {
        public RaceService _raceService;

        [SerializeField] private Transform _horseRaceProgressContainer;
        [SerializeField] private GameObject _horseRaceProgeressPrefab;

        private List<HorseRaceProgressSubcomponent> _horseRaceProgressSubcomponents = new();

        private void Update()
        {
            Refresh();
        }

        public override void Draw()
        {
            var horses = _raceService.Horses;
            foreach (var horse in horses)
            {
                var horseObject = Instantiate(_horseRaceProgeressPrefab, _horseRaceProgressContainer)
                    .GetComponent<HorseRaceProgressSubcomponent>();
                var color = _raceService.SelectedHorse == horse ? Color.yellow : Color.white;
                horseObject.HorseNameText.text = horse.Name;
                horseObject.HorseNameText.color = color;
                horseObject.RelatedHorse = horse;
                _horseRaceProgressSubcomponents.Add(horseObject);
            }

            base.Draw();
        }

        public override void Hide()
        {
            base.Hide();
        }

        public override void Refresh()
        {
            UpdatePlaces();
        }

        private void UpdatePlaces()
        {
            var subcomponentsInOrder = _horseRaceProgressSubcomponents.OrderByDescending(t => t.RelatedHorse.NormalizedRaceProgress);
            var index = 0;
            foreach (var subcomponent in subcomponentsInOrder)
            {
                subcomponent.PlaceText.text = $"#{++index}";
            }
        }
    }
}