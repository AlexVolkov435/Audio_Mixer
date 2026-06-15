using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerVolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;

    [SerializeField] private float _minimumValue = 0.0001f;
    [SerializeField] private float _maximumValue = 1f;
    [SerializeField] private string _mixerParameter;
   
    private void OnEnable()
    {
        if (_slider != null)
            _slider.onValueChanged.AddListener(SetAudioVolume);
    }

    private void OnDisable()
    {
        if (_slider != null)
            _slider.onValueChanged.RemoveListener(SetAudioVolume);
    }

    private void SetAudioVolume(float volume)
    {
        if (_audioMixer == null || string.IsNullOrEmpty(_mixerParameter))
            return;

        float clampedVolume = Mathf.Clamp(volume, _minimumValue, _maximumValue);
        float decibels = Mathf.Log10(clampedVolume) * 20f;

        _audioMixer.SetFloat(_mixerParameter, decibels);
    }
}