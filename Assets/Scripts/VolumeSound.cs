using UnityEngine;
using UnityEngine.Audio;

public class VolumeSound : MonoBehaviour
{
   private const string SoundButton = nameof(SoundButton);
   private const string BackgroundVolume = nameof(BackgroundVolume);
   private const string MasterVolume = nameof(MasterVolume);
   
   [SerializeField] private AudioMixerGroup _mixer;
 
   private float _minimumValue = 0.0001f;
   private float _maximumValue = 1f;
   private float _clampedVolume;
   private float _decibels;
   
   public void ToggleSound(bool enable)
   {
      _mixer.audioMixer.SetFloat(BackgroundVolume, enable ? 0f : -80f);
   }
   
   public void ChangeVolumeButton(float volume)
   { 
      SetAudioVolume (volume,SoundButton);
   }
   
   public void ChangeVolumeAll(float volume)
   {
      SetAudioVolume (volume,MasterVolume);
   }
   
   public void ChangeBackgroundVolume(float volume)
   {
      SetAudioVolume (volume,BackgroundVolume);
   }
   
   private void SetAudioVolume (float volume,string parameterName)
   {
      float clampedVolume = Mathf.Clamp(volume, _minimumValue, _maximumValue);
      float decibels =  Mathf.Log10(clampedVolume) * 20;
      
      _mixer.audioMixer.SetFloat(parameterName, decibels);
   }
}
