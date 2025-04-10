using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HorseRaceProgressSubcomponent : MonoBehaviour
    {
        public TextMeshProUGUI HorseNameText, PlaceText;

        public Slider RaceProgressBar;

        public Horse RelatedHorse;

        private void Update()
        {
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            RaceProgressBar.value = RelatedHorse.NormalizedRaceProgress;
        }
    }
}