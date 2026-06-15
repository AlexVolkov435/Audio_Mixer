using UnityEngine;
using UnityEngine.UI;

public class AudioPlayButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        if (_button != null && _audioSource != null)
            _button.onClick.AddListener(PlaySound);
    }

    private void OnDisable()
    {
        if (_button != null)
            _button.onClick.RemoveListener(PlaySound);
    }

    private void PlaySound()
    {
        if (_audioSource != null)
            _audioSource.Play();
    }
}