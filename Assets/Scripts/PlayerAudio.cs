using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip jump;

    private AudioSource _AudioSource;
    private PlayerInput _Input;
    private PlayerMovement _PlayerMovement;
    
    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        _Input = GetComponent<PlayerInput>();
        _PlayerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {  
         JumpAudio();
    }

    private void JumpAudio()
    {
        if (_Input.jump && (_PlayerMovement.canCoyote || _PlayerMovement.IsGrounded()))
        {
            _AudioSource.pitch = Random.Range(0.5f, 1.5f);
            _AudioSource.PlayOneShot(jump);
        }
    }

    private void AudioShowCase(AudioClip audioClip)
    {
        _AudioSource.Play(); // Play the Audio Clip attached to the AudioSource component
            _AudioSource.clip = audioClip; // Set the attached audioclip to a different clip
        _AudioSource.Pause(); // Pause the AudioClip being played (Only affects the clip attached to the audiosource)
        
        _AudioSource.Stop(); // Stop the AudiClip being played  (Only affects the clip attached to the audiosource)

        _AudioSource.PlayOneShot(audioClip); // Play an independent AudioClip using the AudioSource.
    }
}