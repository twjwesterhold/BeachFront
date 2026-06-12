using UnityEngine;

namespace NPCs
{
    public class FishingRodAnimation : MonoBehaviour
    {
        private Animator _animator;
        private float _speedChangeTimer;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _speedChangeTimer -= Time.deltaTime;
            if (_speedChangeTimer <= 0)
            {
                _animator.speed = Random.Range(0.5f, 1.5f);
                _speedChangeTimer = Random.Range(1f, 3f);
            }
        }
    }
}
