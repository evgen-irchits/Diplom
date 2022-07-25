using Script.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class SetingUI : UIView
    {
        [SerializeField] public Button okButton;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        private void Awake()
        {
            Initialize();
            okButton.onClick.AddListener(() =>  GameContext.Instance.ShowView(nameof(StartUI)));
        }
        public override string ViewName => nameof(SetingUI);
    }
}
