using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Objects
{
    public class Horse : MonoBehaviour
    {
        public Animator Animator;

        public Transform Transform, CameraFollowPoint;

        private Vector3 _targetPosition, _spawnPosition;

        private float _moveSpeed, _basicMoveSpeed = 5f;

        private bool _isActive = false;

        public void Initialize(Vector3 targetPosition, Vector3 spawnPosition)
        {
            _targetPosition = targetPosition;
            _spawnPosition = spawnPosition;
            _moveSpeed = _basicMoveSpeed;
        }

        public void Activate()
        {
            _isActive = true;
        }

        private void FixedUpdate()
        {
            if (_isActive)
                Move();
        }

        private void Move()
        {
            Debug.Log("!");
            Transform.position = Vector3.MoveTowards(Transform.position, _targetPosition, _moveSpeed * Time.fixedDeltaTime);
        }
    }
}