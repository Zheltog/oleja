using Common;
using UnityEngine;

namespace Garden
{
    public class Oleja : MonoBehaviour
    {
        public Player player;
        public Flashlight playerFlashlight;
        public AudioSource voice;
        public float calmSpeed = 1.0f;
        public float runningSpeed = 5.0f;
        public float obstacleCheckRange = 5.0f;
        public float obstacleCheckSphereRadius = 0.75f;
        public float randomTurnMinAngle = -120f;
        public float randomTurnMaxAngle = 120f;
        public float fovAngle = 120f;
        public float seeingDistance = 10f;
        public float hearingDistance = 5f;

        private bool _isAwake;
        private bool _isRunning;
        private GameObject _visible;
        private Rigidbody _rigidbody;
        private BoxCollider _collider;
        private Animator _animator;
        private FootstepsAudioSource _footsteps;

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _footsteps = GetComponentInChildren<FootstepsAudioSource>();
            _visible = transform.GetChild(0).gameObject;
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<BoxCollider>();
            _visible.SetActive(false);
            _rigidbody.useGravity = false;
            _collider.enabled = false;
            _footsteps.ForceDisable();
        }

        private void Update()
        {
            if (!_isAwake)
            {
                return;
            }
            
            Listen();

            if (IsPlayerInFOV() && !IsPlayerBehindObstacle())
            {
                if (!_isRunning)
                {
                    _isRunning = true;
                    _animator.SetBool("Running", true);
                    _footsteps.IncreasePitch(runningSpeed / calmSpeed);
                    voice.Play();
                }
                
                PursuePlayer();
            }
            else
            {
                if (_isRunning)
                {
                    _isRunning = false;
                    _animator.SetBool("Running", false);
                    _footsteps.ResetPitch();
                }
                
                SearchForPlayer();
            }
        }

        public void AwakeOleja()
        {
            _isAwake = true;
            _visible.SetActive(true);
            _collider.enabled = true;
            _rigidbody.useGravity = true;
            _footsteps.ForceEnable();
        }

        private void Listen()
        {
            if (player.IsMoving && !player.IsSquatting && GetDirectionToPlayer().magnitude <= hearingDistance)
            {
                transform.LookAt(player.transform);
            }
        }

        private void PursuePlayer()
        {
            // Debug.Log("I C U");
            transform.LookAt(player.transform);
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
            var directionToTarget = player.GetHeadPosition() - t.position;
            return Vector3.Angle(forwardDirection, directionToTarget) < fovAngle / 2;
        }

        private bool IsPlayerBehindObstacle()
        {
            var direction = GetDirectionToPlayer();
            
            var raycastDistance = direction.magnitude < seeingDistance ? direction.magnitude :
                playerFlashlight.IsOn ? direction.magnitude : seeingDistance;
            
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

        private Vector3 GetDirectionToPlayer()
        {
            return player.GetHeadPosition() - transform.position;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Player>(out Player _))
            {
                if (IsPlayerInFOV())
                {
                    SceneLoader.LoadGameOver();
                }
            }
        }
    }
}