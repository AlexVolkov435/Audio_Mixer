using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioSource audioSource3;
    
    [SerializeField] private Button _buttonSound1;
    [SerializeField] private Button _buttonSound2;
    [SerializeField] private Button _buttonSound3;

    private void OnEnable()
    {
        if (_buttonSound1 != null && audioSource1 != null)
            _buttonSound1.onClick.AddListener(() => PlaySound(audioSource1));
            
        if (_buttonSound2 != null && audioSource2 != null)
            _buttonSound2.onClick.AddListener(() => PlaySound(audioSource2));
            
        if (_buttonSound3 != null && audioSource3 != null)
            _buttonSound3.onClick.AddListener(() => PlaySound(audioSource3));
    }

    private void OnDisable()
    {
        if (_buttonSound1 != null) 
            _buttonSound1.onClick.RemoveAllListeners();
        
        if (_buttonSound2 != null) 
            _buttonSound2.onClick.RemoveAllListeners();
        
        if (_buttonSound3 != null) 
            _buttonSound3.onClick.RemoveAllListeners();
    }
    
    private void PlaySound(AudioSource source)
    {
        if (source != null)
        {
            source.Play();
        }
    }
}