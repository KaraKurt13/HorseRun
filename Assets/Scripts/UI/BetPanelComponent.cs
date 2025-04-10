using Assets.Scripts.Main;
using Assets.Scripts.UI.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class BetPanelComponent : ComponentBase
    {
        public Engine Engine;

        [SerializeField] private RaceService _raceService;
        [SerializeField] private Button _startRaceButton;
        [SerializeField] private Transform _horsesContainer;
        [SerializeField] private GameObject _horseBetPrefab;

        public override void Draw()
        {
            var horses = _raceService.Horses;
            foreach (var horse in horses)
            {
                var horseObject = Instantiate(_horseBetPrefab, _horsesContainer).GetComponent<HorseBetSubcomponent>();
                horseObject.Image.sprite = horse.Image;
                horseObject.NameText.text = horse.Name;
                horseObject.SelectButton.onClick.AddListener(() => 
                {
                    _raceService.SetHorseBet(horse);
                    UpdateHorseBet(horseObject);
                });
            }
            _startRaceButton.onClick.AddListener(() =>
            {
                Engine.StartGame();
            });
            UpdateHorseBet(null);
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

        private HorseBetSubcomponent _selectedHorse;

        public void UpdateHorseBet(HorseBetSubcomponent selectedHorse)
        {
            if (_selectedHorse != null)
                _selectedHorse.NameText.color = Color.white;

            if (selectedHorse != null)
                selectedHorse.NameText.color = Color.yellow;

            _selectedHorse = selectedHorse;

            _startRaceButton.interactable = _raceService.SelectedHorse != null;
        }
    }
}