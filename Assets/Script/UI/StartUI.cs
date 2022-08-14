using System;
using Script.Core;
using Script.Models;
using Script.Service;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class StartUI : UIView
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button settingButton;
        private void Start()
        {
            Initialize();
            
            startButton.onClick.AddListener(() =>
            {
                var sm = GameContext.Instance.SaveService.Load<SaverModel>();
                sm.appeared = 1;
                GameContext.Instance.SaveService.Write(sm);
                GameContext.Instance.ShowView(nameof(VariantGameUI));
            });
            settingButton.onClick.AddListener(() =>  GameContext.Instance.ShowView(nameof(SetingUI)));
        }

        private void Awake()
        {
            
        }

        public override string ViewName => nameof(StartUI);
    }
}
