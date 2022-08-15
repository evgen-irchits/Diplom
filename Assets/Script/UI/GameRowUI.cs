using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Script.Card;
using Script.Core;
using Script.Models;
using Script.Service;
using Script.UI;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameRowUI : UIView
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button verifyButton;
    [SerializeField] private Image[] images;
    [SerializeField] private Image[] clearCard;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameContext gameContext;
    [SerializeField] private Text timerText;
    public AudioSource myfx;
    public AudioClip myVerify;
    public AudioClip myGameOver;
    private RectTransform rectTransfrom;
    public float timerStart = 6;
    private int timerStart2;
    public int r = 36;
    
    private void Start()
    {
        
        Initialize();
        
        backButton.onClick.AddListener(() =>
        {
            for (int i = 0; i < images.Length; i++)
            {
                closeCard();
                timerStart = 6;
            }

            GetComponent<GameRowUI>().StopAllCoroutines();
            GameContext.Instance.ShowView(nameof(GameRowLavelUi));
            r = 36;
        });
        
        verifyButton.onClick.AddListener(() =>
        {
            for (int i = 0; i < images.Length; i++)
            {
                if ((images[i].GetComponent<Card>().active == true) && (images[i].gameObject.transform.position !=
                                                                        clearCard[i].gameObject.transform.position))
                {
                    r--;
                }
            }

            if (r == 36)
            {
                ClickSourseVerify();
                var sm = GameContext.Instance.SaveService.Load<SaverModel>();
                int sl = sm.row;
                if (sl == gameContext.Lave + 1)
                {
                    sm.row = sm.row + 1;
                    GameContext.Instance.SaveService.Write(sm);
                    GameContext.Instance.ShowView(nameof(GameViktoryUI));
                    r = 36;
                }
                else
                {
                    GameContext.Instance.ShowView(nameof(GameViktoryUI));
                    r = 36;
                }

                closeCard();
            }
            else
            {
                closeCard();
                ClickSourseGameOver();
                GameContext.Instance.ShowView(nameof(GameOverUI));
                r = 36;
            }
        });
        
    }

    private void Awake()
    {
        //rectTransfrom = panel.GetComponent<RectTransform>();
        //Debug.Log(rectTransfrom.rect.width);
    }

    private void Update()
    {
        timerStart -= Time.deltaTime;
        timerStart2 = (int) Mathf.Round((float) Convert.ToDouble(timerStart));
        timerText.text = timerStart2.ToString();
        if (timerStart2 == 0)
        {
            timerText.text = "0";
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i].GetComponent<Card>().active == true)
                {
                    images[i].gameObject.transform.DOMove(new Vector3(Random.Range(90, 1000), 90 , 0), 0.01f);
                    images[i].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }

            }
        }else if (timerStart2 <= 0) {timerText.text = "0";}
        
    }

    private void closeCard()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
            clearCard[i].gameObject.SetActive(false);
            images[i].GetComponent<Card>().active = false;
            images[i].gameObject.transform.DOMove(new Vector3(0,0,0),0.1f);
            images[i].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    
    public void ClickSourseVerify()
    {
        myfx.PlayOneShot(myVerify);
    }
    
    public void ClickSourseGameOver()
    {
        myfx.PlayOneShot(myGameOver);
    }
    
    
    public override string ViewName => nameof(GameRowUI);
}