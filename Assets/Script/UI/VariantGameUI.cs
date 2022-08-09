using System;
using Script.Core;
using Script.Service;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class VariantGameUI : UIView
    {
        [SerializeField] private Button rowButton;
        [SerializeField] private Button addButton;
        [SerializeField] private Button disappearedButton;
        [SerializeField] private Button infoRowButton;
        [SerializeField] private Button infoAddButton;
        [SerializeField] private Button infoDisappearedButton;
        private void Start()
        {
            Initialize();
            
            rowButton.onClick.AddListener(() =>
            {
                TempClass.variantGame = 1;
                GameContext.Instance.ShowView(nameof(GameRowLavelUi));
            });
            addButton.onClick.AddListener(() =>
            {
                TempClass.variantGame = 2;
                GameContext.Instance.ShowView(nameof(GameAppearedLavelUi));
            });
            disappearedButton.onClick.AddListener(() =>
            {
                TempClass.variantGame = 3;
                GameContext.Instance.ShowView(nameof(GameDisappearedLavelUi));
            });
            infoRowButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(InfoRowUI));
            });
            infoAddButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(InfoAppeared));
            });
            infoDisappearedButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(InfoDisppeared));
            });
        }
        public override string ViewName => nameof(VariantGameUI);
    }
}
