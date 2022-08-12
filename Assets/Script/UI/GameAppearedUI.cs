using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Script;
using Script.Card;
using Script.Core;
using Script.Service;
using Script.UI;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameAppearedUI : UIView
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button okButton;
    [SerializeField] private Image[] images;
    [SerializeField] private Image[] clearCard;
    [SerializeField] private Image[] newCard;
    [SerializeField] private ImageList imageList;
    [SerializeField] private Text timerText;
    [SerializeField] private Text titleText;
    [SerializeField] private GameContext gameContext;
    public float timerStart = 6;
    private int timerStart2;
    private int active = 0;
    public int r = 36;
    
    private void Awake()
    {
        Initialize();
        backButton.onClick.AddListener(() =>
        {
            for (int i = 0; i < images.Length; i++)
            {
                closeCard();
                timerStart = 6;
            }

            GetComponent<GameDisappearedUI>().StopAllCoroutines();
            GameContext.Instance.ShowView(nameof(GameAppearedLavelUi));
        });
    }
    private void Update()
        {
            timerStart -= Time.deltaTime;
            timerStart2 = (int) Mathf.Round((float) Convert.ToDouble(timerStart));
            timerText.text = timerStart2.ToString();
            if (timerStart2 == 0)
            {
                timerStart = -1;
                timerStart2 = -1;
                timerText.text = "0";
                
                float p = images[TempClass.Ncard + 3].gameObject.transform.position.x + 200;
                images[TempClass.Ncard+4].gameObject.SetActive(true);
                clearCard[TempClass.Ncard+4].gameObject.SetActive(true);
                images[TempClass.Ncard+4].GetComponent<Image>().sprite = imageList.images[Random.Range(0, imageList.images.Length - 6)];
                if (TempClass.Ncard + 3 <= 8)
                {
                    images[TempClass.Ncard+4].gameObject.transform.DOMove(new Vector3(p, 900), .01f);
                    clearCard[TempClass.Ncard+4].gameObject.transform.DOMove(new Vector3(p, 900), .01f);
                    
                }
                else if (TempClass.Ncard + 3 > 8 && TempClass.Ncard + 3 <= 16)
                {
                    images[TempClass.Ncard+4].gameObject.transform.DOMove(new Vector3(p, 690), .01f);
                    clearCard[TempClass.Ncard+4].gameObject.transform.DOMove(new Vector3(p, 690), .01f);
                    
                }
                else
                {
                    images[TempClass.Ncard+4].gameObject.transform.DOMove(new Vector3(p, 480), .01f);
                    clearCard[TempClass.Ncard+4].gameObject.transform.DOMove(new Vector3(p, 480), .01f);
                    
                }
                
                for (int i = 0; i < images.Length; i++)
                {
                    if (images[i].GetComponent<Card>().active == true)
                    {
                        active = i;
                    }
                }

                for (int i = 0; i < active + 1; i++)
                {
                    images[i].gameObject.transform
                        .DOMove(new Vector3(Random.Range(90, 1700), Random.Range(300, 1100), 0), 0.01f);
                    images[i].gameObject.transform.DOMove(
                        new Vector3(clearCard[i].gameObject.transform.position.x,
                            clearCard[i].gameObject.transform.position.y,
                            clearCard[i].gameObject.transform.position.z), 0.01f);
                }

                int[] m = new int[TempClass.Ncard+4];
                int x = 0;
                while (x < TempClass.Ncard+4)
                {
                    int temp = Random.Range(0, TempClass.Ncard+4);
                    if (m[temp] == 0)
                    {
                        m[temp] = x;
                        ++x;
                    }                
                }
                
                for (int i = 0; i < TempClass.Ncard+4; i++)
                {
                    images[i].gameObject.transform.DOMove(
                        new Vector3(clearCard[m[i]].gameObject.transform.position.x,
                                clearCard[m[i]].gameObject.transform.position.y,
                                clearCard[m[i]].gameObject.transform.position.z), 0.01f);
                }
            }
            else if (timerStart2 <= 0)
            {
                timerText.text = "0";
            }
        }
    private void closeCard()
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].gameObject.SetActive(false);
                clearCard[i].gameObject.SetActive(false);
                images[i].GetComponent<Card>().active = false;
                images[i].gameObject.transform.DOMove(new Vector3(0, 0, 0), 0.1f);
                images[i].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }

            for (int i = 0; i < newCard.Length; i++)
            {
                newCard[i].gameObject.SetActive(false);
            }
        }
    public override string ViewName => nameof(GameAppearedUI);
}
