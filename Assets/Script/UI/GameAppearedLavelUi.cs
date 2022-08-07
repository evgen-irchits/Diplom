using Script.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class GameAppearedLavelUi : UIView
    {
        [SerializeField] private Button backButton;
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
            
            backButton.onClick.AddListener(() => { GameContext.Instance.ShowView(nameof(VariantGameUI)); });
        }
        public override string ViewName => nameof(GameAppearedLavelUi);
    }
}
