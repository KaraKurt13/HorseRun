using Assets.Scripts.Infrastructure;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class Engine : MonoBehaviour
    {
        private AllServices _services;

        private GameStateMachine _gameStateMachine;

        private void Awake()
        {
            RegisterServices();
            _gameStateMachine = new(_services, this);
        }

        private void Update()
        {
            _gameStateMachine.UpdateState();
        }

        private void FixedUpdate()
        {
            _gameStateMachine.UpdateStatePhysics();
        }
        #region Services
        [SerializeField] private CameraService _cameraService;
        [SerializeField] private UIComponentsService _uiComponentsService;
        [SerializeField] private RaceService _raceService;

        private void RegisterServices()
        {
            RegisterCameraService();
            RegisterRaceService();
            RegisterUIService();
        }

        private void RegisterCameraService()
        {
            _services.RegisterSingle<ICameraService>(_cameraService);
        }

        private void RegisterUIService()
        {
            _services.RegisterSingle<IUIComponentsService>(_uiComponentsService);
        }

        private void RegisterRaceService()
        {
            _services.RegisterSingle<IRaceService>(_raceService);
        }
        #endregion Services
    }
}
