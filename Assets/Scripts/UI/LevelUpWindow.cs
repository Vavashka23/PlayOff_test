using System.Collections.Generic;
using Project.Services;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Project.UI
{
    public class LevelUpWindow : MonoBehaviour, IWindow
    {
        [Header("UI References")] 
        [SerializeField] private Image _backgroundFader;
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private Button _closeButton;
        [SerializeField] private RewardItemViewModel _rewardItemPrefab;
        [SerializeField] private Transform _rewardContainer;

        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private List<RewardItemViewModel> _models = new List<RewardItemViewModel>();
        
        [Inject] private ILevelService _levelService;

        public bool IsPopup => true;

        public void Init()
        {
            _closeButton.OnClickAsObservable()
                .Subscribe(_ => Hide())
                .AddTo(_disposables);
        }
        
        public void Show()
        {
            var data = _levelService.CurrentLevel.Value;
            
            _titleText.text = $"Level {data.LevelNumber}";
            
            foreach (var reward in data.Rewards)
            {
                var item = Instantiate(_rewardItemPrefab, _rewardContainer);
                item.Setup(reward);
                _models.Add(item);
            }
            
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);

            foreach (var model in _models.ToArray())
            {
                Destroy(model.gameObject);
            }
            _models.Clear();
        }

        private void OnDestroy() => _disposables.Dispose();
    }
}
