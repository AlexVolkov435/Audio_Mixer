using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSound : MonoBehaviour
{
   private const string SoundButton = nameof(SoundButton);
   private const string BackgroundVolume = nameof(BackgroundVolume);
   private const string MasterVolume = nameof(MasterVolume);
   
   [SerializeField] private AudioMixer _audioMixer;
   [SerializeField] private Slider _masterSlider;
   [SerializeField] private Slider _backgroundSlider;
   [SerializeField] private Slider _buttonSoundSlider;
 
   private float _minimumValue = 0.0001f;
   private float _maximumValue = 1f;
   private float _clampedVolume;
   private float _decibels;

   private void OnEnable()
   {
      if (_masterSlider != null)
         _masterSlider.onValueChanged.AddListener(ChangeVolumeAll);

      if (_backgroundSlider != null)
         _backgroundSlider.onValueChanged.AddListener(ChangeBackgroundVolume);
      
      if(_buttonSoundSlider != null)
         _buttonSoundSlider.onValueChanged.AddListener(ChangeVolumeButton);
   }

   private void OnDisable()
   {
      if (_masterSlider != null)
         _masterSlider.onValueChanged.RemoveListener(ChangeVolumeAll);

      if (_backgroundSlider != null)
         _backgroundSlider.onValueChanged.RemoveListener(ChangeBackgroundVolume);
      
      if(_buttonSoundSlider != null)
         _backgroundSlider.onValueChanged.RemoveListener(ChangeVolumeButton);
   }

   private void ChangeVolumeAll(float volume)
   {
      SetAudioVolume(volume,MasterVolume);
   }
   
   private void ChangeBackgroundVolume(float volume)
   {
      SetAudioVolume (volume,BackgroundVolume);
   }
   
   private void ChangeVolumeButton(float volume)
   { 
      SetAudioVolume (volume,SoundButton);
   }
   
   private void SetAudioVolume (float volume,string parameterName)
   {
      float clampedVolume = Mathf.Clamp(volume, _minimumValue, _maximumValue);
      float decibels =  Mathf.Log10(clampedVolume) * 20;
      
      _audioMixer.SetFloat(parameterName, decibels);
   }
}
