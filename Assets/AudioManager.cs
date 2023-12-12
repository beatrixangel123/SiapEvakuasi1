using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [Header ("---------- Audio Source ----------")]
   [SerializeField] AudioSource musicSource;
   [SerializeField] AudioSource SFXSource;

   [Header ("---------- Audio Clip ----------")]
   public AudioClip background;
   public AudioClip death;
   public AudioClip wallTouch;
   public AudioClip nextLevel;

   private void Awake ()
   {
    DontDestroyOnLoad (gameObject);
   }


   private void Start()
   {
    musicSource.clip = background;
    musicSource.Play();
   }

   public void PlaySFX(AudioClip clip)
   {
    SFXSource.PlayOneShot(clip);
   }


}
