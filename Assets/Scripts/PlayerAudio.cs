using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip land;
    public AudioClip walking;

    private AudioSource _audioSource;
    private PlayerInput _input;
    private PlayerMovement _movement;
    private PlayerCollision _collision;

    private bool _canLand;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _input = GetComponent<PlayerInput>();
        _movement = GetComponent<PlayerMovement>();
        _collision = GetComponent<PlayerCollision>();
    }

    private void Update()
    {
        JumpAudio(); 
        LandingAudio();
    }

    public void WalkingAudio()
    {
        if (_collision.IsGrounded() && _input.moveVector.x != 0)
        {
            _audioSource.pitch = Random.Range(0.5f, 1.5f); 
            _audioSource.PlayOneShot(walking);                
        }
    }

    private void JumpAudio()
    {
        if (_input.jump && (_movement.canCoyote || _collision.IsGrounded()))
        {
            _audioSource.pitch = Random.Range(0.5f, 1.5f);
            _audioSource.PlayOneShot(jump);
        }
    }

    private void LandingAudio()
    {
        if (_collision.IsGrounded() && _canLand)
        {
            _audioSource.pitch = Random.Range(0.5f, 1.5f);
            _audioSource.PlayOneShot(land);
            _canLand = false;
        }
        else if (!_collision.IsGrounded())
        {
            _canLand = true;
        }
    }

    private void AudioShowCase(AudioClip audioClip)
    {
        _audioSource.Play(); // Play the Audio Clip attached to the AudioSource component
            _audioSource.clip = audioClip; // Set the attached audioclip to a different clip
        _audioSource.Pause(); // Pause the AudioClip being played (Only affects the clip attached to the audiosource)
        
        _audioSource.Stop(); // Stop the AudiClip being played  (Only affects the clip attached to the audiosource)

        _audioSource.PlayOneShot(audioClip); // Play an independent AudioClip using the AudioSource.
    }
}