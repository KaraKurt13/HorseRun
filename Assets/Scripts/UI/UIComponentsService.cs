using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public interface IUIComponentsService : IService
    {
        public void DrawRacePanel();

        public void HideRacePanel();

        public void DrawResultScreen();

        public void HideResultScreen();

        public void DrawBetPanel();

        public void HideBetPanel();
    }

    public class UIComponentsService : MonoBehaviour, IUIComponentsService
    {
        [SerializeField] private BetPanelComponent _betPanelComponent;
        [SerializeField] private RacePanelComponent _racePanelComponent;
        [SerializeField] private GameResultsComponent _gameResultsComponent;

        public void DrawBetPanel()
        {
            _betPanelComponent.Draw();
        }

        public void DrawRacePanel()
        {
            _racePanelComponent.Draw();
        }

        public void DrawResultScreen()
        {
            _gameResultsComponent.Draw();
        }

        public void HideBetPanel()
        {
            _betPanelComponent.Hide();
        }

        public void HideRacePanel()
        {
            _racePanelComponent.Hide();
        }

        public void HideResultScreen()
        {
            _gameResultsComponent.Hide();
        }
    }
}