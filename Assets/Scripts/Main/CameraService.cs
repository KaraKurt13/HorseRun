using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public interface ICameraService : IService
    {
        public void SetCameraFollowing(Transform followPoint, bool instantly = false);

        public void SetCameraSideView(bool instantly = false);
    }

    public class CameraService : MonoBehaviour, ICameraService
    {
        private Camera _camera;

        private CameraStateEnum _state = CameraStateEnum.SideView;

        [SerializeField]
        private Transform _sideView, _followView;

        private bool _isMoving = false;

        public void Init()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_state == CameraStateEnum.Following && !_isMoving)
                UpdateFollowingPosition();
        }

        private IEnumerator MoveCamera(Transform start, Transform end, float duration)
        {
            var elapsedTime = 0f;
            var startPos = start.position;
            var startRot = start.localRotation;
            _isMoving = true;

            while (elapsedTime < duration)
            {
                var progress = elapsedTime / duration;
                Camera.main.transform.position = Vector3.Lerp(startPos, end.position, progress);
                Camera.main.transform.localRotation = Quaternion.Slerp(startRot, end.localRotation, progress);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            Camera.main.transform.localPosition = end.position;
            Camera.main.transform.localRotation = end.localRotation;
            _isMoving = false;
        }

        public void SetCameraFollowing(Transform followPoint, bool instantly = false)
        {
            var changeTime = instantly ? 0f : 2f;
            _followView = followPoint;
            _state = CameraStateEnum.Following;
            StartCoroutine(MoveCamera(_sideView, followPoint, changeTime));
        }

        public void SetCameraSideView(bool instantly = false)
        {
            var changeTime = instantly ? 0f : 2f;
            _state = CameraStateEnum.SideView;
            StartCoroutine(MoveCamera(Camera.main.transform, _sideView, changeTime));
        }

        private void UpdateFollowingPosition()
        {
            Camera.main.transform.position = _followView.position;
        }
    }
}