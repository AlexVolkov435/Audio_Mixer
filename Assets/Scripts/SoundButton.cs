using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioSource audioSource3;

    public void TurnFirstSound()
    {
        audioSource1.Play();
    }
    
    public void TurnSecondSound()
    {
        audioSource2.Play();
    }
    
    public void TurnThirdSound()
    {
        audioSource3.Play();
    }
}