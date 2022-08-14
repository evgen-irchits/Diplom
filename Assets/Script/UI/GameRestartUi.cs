using Script.Core;
using Script.Models;
using Script.Service;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class GameRestartUi : MonoBehaviour
    {
        [SerializeField] public Button okButton;
        [SerializeField] public Button ResetButton;
        [SerializeField] public Canvas gameRestart;

        private void Start()
        {
            okButton.onClick.AddListener(() =>
            {
                gameRestart.GameObject().SetActive(false);
            });
            ResetButton.onClick.AddListener(() =>
            {
                var sm = GameContext.Instance.SaveService.Load<SaverModel>();
                sm.row = 1;
                sm.disappeared = 1;
                GameContext.Instance.SaveService.Write(sm);
                gameRestart.GameObject().SetActive(false);
            });
        }
       
    }
}