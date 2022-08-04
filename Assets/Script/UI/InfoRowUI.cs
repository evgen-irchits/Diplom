using Script.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class InfoRowUI : UIView
    {
        [SerializeField] public Button backButton;
        private void Awake()
        {
            Initialize();
            backButton.onClick.AddListener(() =>  GameContext.Instance.ShowView(nameof(VariantGameUI)));
        }
        public override string ViewName => nameof(InfoRowUI);
    }
}