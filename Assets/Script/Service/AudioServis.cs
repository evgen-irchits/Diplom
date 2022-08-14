using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioServis : MonoBehaviour
{

    [SerializeField] public AudioMixer audioMixer;
    
    
    public void SetVolum(float volume)
    {
        audioMixer = GetComponent<AudioMixer>();
        
    }

}
