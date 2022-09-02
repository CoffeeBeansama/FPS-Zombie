using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Zombie.Sounds
{

    [RequireComponent(typeof(AudioSource))]
    
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance { get; private set; }
        private AudioSource source;

        public AudioSource BackGroundMusic;

        private void Start()
        {
            BackGroundMusic.Play();
        }

        private void Awake()
        {
            instance = this;
            source = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioClip sfx)
        {
            source.PlayOneShot(sfx);
        }
    }
}
