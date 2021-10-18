using UnityEngine;

namespace PlayerScripts
{
    public class PlayerParticles : MonoBehaviour
    {
        public static ParticleSystem DustParticles;
        public GameObject _DustParticles;
        
        public static ParticleSystem ConfettiParticles;
        public GameObject _ConfettiParticles;

        private void Start()
        {
            DustParticles = _DustParticles.GetComponent<ParticleSystem>();
            ConfettiParticles = _ConfettiParticles.GetComponent<ParticleSystem>();
        }

        public static void CreateDust()
        {
            DustParticles.Play();
        }
        
        public static void CreateConfetti()
        {
            ConfettiParticles.Play();
        }
    }
}
