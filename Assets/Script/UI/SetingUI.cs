using System;
using Script.Core;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Script.UI
{
    public class SetingUI : UIView
    {
        [SerializeField] public Button okButton;
        
        public AudioMixer audioMixer;

        private void Awake()
        {
            Initialize();
            okButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(StartUI));
            });
        }

        public void Soud()
        {
            AudioListener.pause = !AudioListener.pause;
        }

        public void SetVolume(float volum)
        {
            audioMixer.SetFloat("volume", Mathf.Log10(volum) * 20);
        }
     
        public override string ViewName => nameof(SetingUI);
    }
}
