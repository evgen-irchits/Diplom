using System.Collections;
using System.Collections.Generic;
using Script.Core;
using Script.UI;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisppeared : UIView
{
    [SerializeField] public Button backButton;
    private void Awake()
    {
        Initialize();
        backButton.onClick.AddListener(() =>  GameContext.Instance.ShowView(nameof(VariantGameUI)));
    }
    public override string ViewName => nameof(InfoDisppeared);
}
