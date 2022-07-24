using System;
using System.Linq;
using Script.Interface;
using Script.Models;
using Script.Service;
using Script.UI;
using UnityEngine;

namespace Script.Core
{
    public class GameContext : MonoBehaviour
    {
        [SerializeField] public int Lave;
        [SerializeField] private UIView[] views;
        private UIView _currentView;
        public static GameContext Instance;

        public ISaveService SaveService { get; private set; }

        private void Start()
        {
            _currentView = views.First(v => v.ViewName == nameof(StartUI));
            _currentView.Show();
        }

        private void Awake()
        {
            SaveService = new SaveService();

            CheckModels();

            if (Instance == null) Instance = this;
        }

        public void ShowView(string viewName)
        {
            var tweener = _currentView.Hide();
            tweener.onComplete += () =>
            {
                _currentView = views.First(v => v.ViewName == viewName);
                _currentView.Show();
            };
        }

        private void CheckModels()
        {
            var s = SaveService.Load<SaverModel>();
            if (s == null)
            {
                s = new SaverModel();
                SaveService.Write(s);
            }
        }
    }
}
