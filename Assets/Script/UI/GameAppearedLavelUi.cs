using UnityEngine;

namespace Script.UI
{
    public class GameAppearedLavelUi : UIView
    {
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
        }
        public override string ViewName => nameof(GameAppearedLavelUi);
    }
}
