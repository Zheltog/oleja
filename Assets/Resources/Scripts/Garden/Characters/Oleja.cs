using Common;
using UnityEngine;

namespace Garden
{
    public class Oleja : MonoBehaviour
    {
        public Transform playerHead;
        public Transform playerMain;
        public float calmSpeed = 1.0f;
        public float runningSpeed = 5.0f;
        public float obstacleCheckRange = 5.0f;
        public float obstacleCheckSphereRadius = 0.75f;
        public float randomTurnMinAngle = -110f;
        public float randomTurnMaxAngle = 110f;
        public float fovAngle = 60f;
        public float fovDistance = 10f;

        private bool _isAwake;
        private GameObject _visible;
        private BoxCollider _collider;

        private void Start()
        {
            _visible = transform.GetChild(0).gameObject;
            _collider = GetComponent<BoxCollider>();
            _visible.SetActive(false);
            _collider.enabled = false;
        }

        private void Update()
        {
            if (!_isAwake)
            {
                return;
            }

            if (IsPlayerInFOV() && !IsPlayerBehindObstacle())
            {
                PursuePlayer();
            }
            else
            {
                SearchForPlayer();
            }
        }

        public void AwakeOleja()
        {
            _isAwake = true;
            _visible.SetActive(true);
            _collider.enabled = true;
        }

        private void PursuePlayer()
        {
            // Debug.Log("I C U");
            transform.LookAt(playerMain);
            transform.Translate(0, 0, runningSpeed * Time.deltaTime);
        }

        private void SearchForPlayer()
        {
            var t = transform;
            t.Translate(0, 0, calmSpeed * Time.deltaTime);
            var ray = new Ray(t.position, t.forward);

            if (!Physics.SphereCast(ray, obstacleCheckSphereRadius, out var hit))
            {
                return;
            }

            if (!(hit.distance < obstacleCheckRange))
            {
                return;
            }

            var turnAngle = Random.Range(randomTurnMinAngle, randomTurnMaxAngle);
            transform.Rotate(0, turnAngle, 0);
        }

        private bool IsPlayerInFOV()
        {
            var t = transform;
            var forwardDirection = t.forward;
            var directionToTarget = playerHead.position - t.position;
            return Vector3.Angle(forwardDirection, directionToTarget) < fovAngle / 2;
        }

        private bool IsPlayerBehindObstacle()
        {
            var direction = playerHead.position - transform.position;
            var raycastDistance = direction.magnitude < fovDistance ? direction.magnitude : fovDistance;
            var ray = new Ray(transform.position, direction.normalized);
            var hits = Physics.RaycastAll(ray, raycastDistance);

            if (hits.Length == 0)
            {
                return true;
            }

            foreach (var hit in hits)
            {
                if (!hit.transform.TryGetComponent<Player>(out Player _))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Player>(out Player _))
            {
                SceneLoader.LoadGameOver();
            }
        }
    }
}