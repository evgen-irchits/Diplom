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

       private SaverModel _saveService = new SaverModel();
        private void Start()
        {
            Initialize();
            
            startButton.onClick.AddListener(() =>
            {
                var sm = GameContext.Instance.SaveService.Load<SaverModel>();
                sm.row = 10;
                GameContext.Instance.SaveService.Write(sm);
                GameContext.Instance.ShowView(nameof(VariantGameUI));
            });
        }
        
        public override string ViewName => nameof(StartUI);
    }
}
