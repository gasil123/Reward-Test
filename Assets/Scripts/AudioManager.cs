using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource popEffect;
    public AudioSource reawardEffect;
    public AudioSource decidempEffect;
    private void Awake()
    {
        instance = this;
    }

    public void PlayPopEffect()
    {
        popEffect.Play();
    } 
    public void PlayRewardEffect()
    {
        reawardEffect.Play();
    }
    public void PlayDecidemp()
    {
        decidempEffect.Play();
    }

}
