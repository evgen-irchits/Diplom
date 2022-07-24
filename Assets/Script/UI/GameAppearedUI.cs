using System.Collections;
using System.Collections.Generic;
using Script.UI;
using UnityEngine;

public class GameAppearedUI : UIView
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
    public override string ViewName => nameof(GameAppearedUI);
}
