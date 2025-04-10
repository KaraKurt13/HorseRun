using Assets.Scripts.Main;
using Assets.Scripts.UI.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GameResultsComponent : ComponentBase
    {
        public RaceService RaceService;

        [SerializeField] private Transform _resultsContainer;
        [SerializeField] private GameObject _resultPrefab;

        public void RefreshResultTable()
        {
            if (gameObject.activeSelf == false)
                return;

            foreach (Transform child in _resultsContainer)
                Destroy(child.gameObject);

            var index = 0;
            foreach (var horse in RaceService.ResultsQueue)
            {
                var resultObject = Instantiate(_resultPrefab, _resultsContainer).GetComponent<RaceResultSubcomponent>();
                resultObject.HorseName.text = horse.Name;
                resultObject.RacePlace.text = $"#{++index}";
                var color = RaceService.SelectedHorse == horse ? Color.yellow : Color.white;
                resultObject.RacePlace.color = color;
            }
        }

        public override void Draw()
        {
            RefreshResultTable();
            base.Draw();
        }

        public override void Hide()
        {
            base.Hide();
        }

        public override void Refresh()
        {
            base.Refresh();
        }
    }
}