using UnityEngine;

namespace Script.UI
{
    public class GameOverUI : UIView
    {
       void Start()
        {
            Initialize();
        }

        void Update()
        {
        
        }
        private void Awake()
        {
            
        }
        public override string ViewName => nameof(GameOverUI);
    }
}
