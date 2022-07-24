using System;
using Script.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class VariantGameUI : UIView
    {
        [SerializeField] private Button rowButton;
        [SerializeField] private Button addButton;
        [SerializeField] private Button disappearedButton;
        private void Start()
        {
            Initialize();
            
            rowButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(GameRowLavelUi));
            });
            addButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(GameAppearedLavelUi));
            });
            disappearedButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(GameDisappearedLavelUi));
            });
        }
        public override string ViewName => nameof(VariantGameUI);
    }
}
