using Assets.Scripts.Main;
using Assets.Scripts.UI.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class BetPanelComponent : ComponentBase
    {
        [SerializeField] private IRaceService _raceService;

        public override void Draw()
        {
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