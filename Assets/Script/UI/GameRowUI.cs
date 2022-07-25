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
    private SaverModel _saveService = new SaverModel();
    private RectTransform rectTransfrom;
    private float timerStart = 5;
    private int timerStart2;
    private void Start()
    {
        
        Initialize();
        
        backButton.onClick.AddListener(() =>
        {
            for (int i = 0; i < images.Length; i++)
            {
                closeCard();
                timerStart = 5;
            }

            GetComponent<GameRowUI>().StopAllCoroutines();
            GameContext.Instance.ShowView(nameof(GameRowLavelUi));
        });
        
        verifyButton.onClick.AddListener(() =>
        {
            int r = 36;
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i].GetComponent<Card>().active == true)
                {
                    if (images[i].gameObject.transform.position != clearCard[i].gameObject.transform.position)
                    {
                        r--;
                    }
                }
            }
            if (r == 36)
            {
                closeCard();
                var sm = GameContext.Instance.SaveService.Load<SaverModel>();
                sm.row = sm.row + 1;
                GameContext.Instance.SaveService.Write(sm);
                GameContext.Instance.ShowView(nameof(GameViktoryUI));
            }
            else
            {
                closeCard();
                GameContext.Instance.ShowView(nameof(GameOverUI));
            }
        });
        
    }

    private void Awake()
    {
        rectTransfrom = panel.GetComponent<RectTransform>();
        Debug.Log(rectTransfrom.rect.width);
    }

    private void Update()
    {
        timerStart -= Time.deltaTime;
        timerStart2 = (int) Mathf.Round((float) Convert.ToDouble(timerStart));
        
        if (timerStart2 == 0)
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i].GetComponent<Card>().active == true)
                {
                    images[i].gameObject.transform.DOMove(new Vector3(Random.Range(90, 1700), 100 , 0), 0.01f);
                    images[i].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }

            }
        }
    }

    private void closeCard()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
            clearCard[i].gameObject.SetActive(false);
            images[i].gameObject.transform.DOMove(new Vector3(0,0,0),0.1f);
            images[i].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    public override string ViewName => nameof(GameRowUI);
}