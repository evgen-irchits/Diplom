using System;
using DG.Tweening;
using Script.Core;
using Script.Service;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Script.UI
{
    public class GameOverUI : UIView
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private Image[] images;
        [SerializeField] private Image[] clearCard;
        [SerializeField] private ImageList imageList;
        [SerializeField] private GameRowUI gameRowUI;
        [SerializeField] private GameDisappearedUI gameDisappearedUI;
        [SerializeField] private GameAppearedUI gameAppearedUI;
        void Start()
        {
            Initialize();
            menuButton.onClick.AddListener(() => GameContext.Instance.ShowView(nameof(StartUI)));
            restartButton.onClick.AddListener(() =>
            {
                if (TempClass.variantGame == 1)
                {
                    GameContext.Instance.ShowView(nameof(GameRowUI));
                    gameRowUI.timerStart = 5;
                    var rom = GameContext.Instance.Lave;
                    float p = 120, p1 = 120, p2 = 120;
                    decimal x = rom / 3;
                    x = Math.Truncate(x);
                    int x1 = Convert.ToInt32(x);
                    int[] image = new int[x1 + 3];
                    image[0] = Random.Range(0, 62);
                    for (int j = 0; j < x + 3; j++)
                    {
                        images[j].gameObject.SetActive(true);
                        clearCard[j].gameObject.SetActive(true);
                        images[j].GetComponent<Card.Card>().active = true;
                        image[j] = Random.Range(0, imageList.images.Length);
                        if (j != 0)
                        {
                            if (image[j] != image[j - 1])
                                images[j].GetComponent<Image>().sprite = imageList.images[image[j]];
                            else
                                images[j].GetComponent<Image>().sprite =
                                    imageList.images[Random.Range(0, imageList.images.Length)];
                        }
                        else
                            images[j].GetComponent<Image>().sprite =
                                imageList.images[Random.Range(0, imageList.images.Length)];

                        if (j <= 8)
                        {
                            images[j].gameObject.transform.DOMove(new Vector3(p, 900), .9f);
                            clearCard[j].gameObject.transform.DOMove(new Vector3(p, 900), .9f);
                            p = p + 200;
                        }
                        else if (j > 8 && j <= 16)
                        {
                            images[j].gameObject.transform.DOMove(new Vector3(p1, 690), .9f);
                            clearCard[j].gameObject.transform.DOMove(new Vector3(p1, 690), .9f);
                            p1 = p1 + 200;
                        }
                        else
                        {
                            images[j].gameObject.transform.DOMove(new Vector3(p2, 480), .9f);
                            clearCard[j].gameObject.transform.DOMove(new Vector3(p2, 480), .9f);
                            p2 = p2 + 200;
                        }
                    }
                }
                if (TempClass.variantGame == 3)
                {
                    GameContext.Instance.ShowView(nameof(GameDisappearedUI));
                    gameDisappearedUI.timerStart = 6;
                    var Disappeared = GameContext.Instance.Lave;
                    float p = 120, p1 = 120, p2 = 120;
                    decimal x = Disappeared / 3;
                    x = Math.Truncate(x);
                    int x1 = Convert.ToInt32(x);
                    int[] image = new int[x1 + 3];
                    image[0] = Random.Range(0, 62);
                    for (int j = 0; j < x + 3; j++)
                    {
                        images[j].gameObject.SetActive(true);
                        clearCard[j].gameObject.SetActive(true);
                        images[j].GetComponent<Card.Card>().active = true;
                        image[j] = Random.Range(0, imageList.images.Length);
                        if (j != 0)
                        {
                            if (image[j] != image[j - 1])
                                images[j].GetComponent<Image>().sprite = imageList.images[image[j]];
                            else
                                images[j].GetComponent<Image>().sprite =
                                    imageList.images[Random.Range(0, imageList.images.Length)];
                        }
                        else
                            images[j].GetComponent<Image>().sprite =
                                imageList.images[Random.Range(0, imageList.images.Length)];

                        if (j <= 8)
                        {
                            images[j].gameObject.transform.DOMove(new Vector3(p, 900), .9f);
                            clearCard[j].gameObject.transform.DOMove(new Vector3(p, 900), .9f);
                            p = p + 200;
                        }
                        else if (j > 8 && j <= 16)
                        {
                            images[j].gameObject.transform.DOMove(new Vector3(p1, 690), .9f);
                            clearCard[j].gameObject.transform.DOMove(new Vector3(p1, 690), .9f);
                            p1 = p1 + 200;
                        }
                        else
                        {
                            images[j].gameObject.transform.DOMove(new Vector3(p2, 480), .9f);
                            clearCard[j].gameObject.transform.DOMove(new Vector3(p2, 480), .9f);
                            p2 = p2 + 200;
                        }
                    }
                }
            });
        }
        public override string ViewName => nameof(GameOverUI);
    }
}
