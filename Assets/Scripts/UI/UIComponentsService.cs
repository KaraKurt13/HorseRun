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
        public void DrawBetPanel()
        {
        }

        public void DrawRacePanel()
        {
        }

        public void DrawResultScreen()
        {
        }

        public void HideBetPanel()
        {
        }

        public void HideRacePanel()
        {
        }

        public void HideResultScreen()
        {
        }
    }
}