using Project.Services;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Project.UI
{
    public class MainWindow : MonoBehaviour, IWindow
    {
        [Header("UI References")] 
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private Button _updateButton;
        
        [Inject] private ILevelService _levelService;
        [Inject] private UIController _uiController;
        
        private CompositeDisposable _disposables;

        public bool IsPopup => false;

        public void Init()
        {
            _disposables = new CompositeDisposable();
            
            _updateButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _levelService.GenerateNextLevel();
                    ShowPopup();
                })
                .AddTo(_disposables);

            _levelService.CurrentLevel
                .Subscribe(model => _levelText.text = $"Level {model.LevelNumber}")
                .AddTo(_disposables);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void ShowPopup()
        {
            _uiController.ShowWindow<LevelUpWindow>();
        }

        private void OnDestroy() => _disposables?.Dispose();
    }
}
