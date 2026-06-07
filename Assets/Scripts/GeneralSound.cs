using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GeneralSound : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
   
    private const float UnMutedDecibels = 0f;
    private const float MutedDecibels = -80f;
    
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Button _muteButton;
    
    private bool _isMuted;
    
    private void OnEnable()
    {
        if (_muteButton != null)
            _muteButton.onClick.AddListener(ToggleSound);
    }

    private void OnDisable()
    {
        if (_muteButton != null)
            _muteButton.onClick.RemoveListener(ToggleSound);
    }

    private void ToggleSound()
    {
        _isMuted = !_isMuted;
        
        float targetDecibels  = _isMuted ? MutedDecibels : UnMutedDecibels;
        
        _audioMixer.SetFloat(MasterVolume, targetDecibels);
    }
}