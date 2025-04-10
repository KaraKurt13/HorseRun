using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Objects
{
    public class Horse : MonoBehaviour
    {
        public Animator Animator;

        public SkinnedMeshRenderer MeshRenderer;

        public Transform Transform, CameraFollowPoint;

        public string Name { get; private set; }

        public float NormalizedRaceProgress 
        {
            get
            {
                var currentDistance = Vector3.Distance(_startPosition, transform.position);
                return Mathf.Clamp01(currentDistance / _totalDistance);
            }
        }

        private Vector3 _targetPosition, _startPosition;
        private float _totalDistance;

        private float _moveSpeed, _basicMoveSpeed = 8f, _targetMoveSpeed;

        private bool _isActive = false;

        public void Initialize(Vector3 targetPosition, Vector3 spawnPosition, string name, Material meshMaterial)
        {
            _targetPosition = targetPosition;
            _startPosition = spawnPosition;
            _moveSpeed = _basicMoveSpeed;
            _totalDistance = Vector3.Distance(_startPosition, _targetPosition);
            _ticksTillSpeedChange = TimeHelper.SecondsToTicks(Random.Range(1f, 3f));
            Name = name;
            MeshRenderer.material = meshMaterial;
        }

        public void Activate()
        {
            _isActive = true;
            // set running animation
        }

        public void Deactivate()
        {
            _isActive = false;
            // Set idle animation
        }

        private void FixedUpdate()
        {
            if (_isActive)
                Move();
        }

        private int _ticksTillSpeedChange;

        private bool _isSpeedChanging = false;

        private void Move()
        {
            if (_isSpeedChanging)
            {
                _moveSpeed = Mathf.MoveTowards(_moveSpeed, _targetMoveSpeed, 0.05f * Time.fixedDeltaTime);

                if (Mathf.Abs(_moveSpeed - _targetMoveSpeed) < 0.01f)
                {
                    _isSpeedChanging = false;
                    _ticksTillSpeedChange = TimeHelper.SecondsToTicks(Random.Range(1f, 3f));
                }
            }
            else
            {
                _ticksTillSpeedChange--;
                if (_ticksTillSpeedChange <= 0)
                {
                    float offset = Random.Range(-2f, 2f);
                    _targetMoveSpeed = Mathf.Max(0f, _basicMoveSpeed + offset);
                    _isSpeedChanging = true;
                }
            }

            Transform.position = Vector3.MoveTowards(Transform.position, _targetPosition, _moveSpeed * Time.fixedDeltaTime);
        }
    }
}