using System.Collections;
using System.Collections.Generic;
using Script;
using Script.Core;
using Script.UI;
using UnityEngine;
using UnityEngine.UI;

public class GameAppearedUI : UIView
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button okButton;
    [SerializeField] private Image[] images;
    [SerializeField] private Image[] clearCard;
    [SerializeField] private Image[] newCard;
    [SerializeField] private ImageList imageList;
    [SerializeField] private Text timerText;
    [SerializeField] private GameContext gameContext;
    public float timerStart = 6;
    private int timerStart2;
    private int active = 0;
    public int r = 36;
    
    private void Awake()
    {
        Initialize();
    }
    public override string ViewName => nameof(GameAppearedUI);
}
