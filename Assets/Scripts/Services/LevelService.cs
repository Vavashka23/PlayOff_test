using System.Collections.Generic;
using Project.Datas;
using Project.Settings;
using UniRx;

namespace Project.Services
{
    public class LevelService : ILevelService
    {
        private readonly ReactiveProperty<LevelData> _currentLevel = new ReactiveProperty<LevelData>();
        private readonly MainSettings _mainSettings;

        public IReadOnlyReactiveProperty<LevelData> CurrentLevel => _currentLevel;

        public LevelService(MainSettings settings)
        {
            _mainSettings = settings;
            GenerateNextLevel();
        }

        public void GenerateNextLevel()
        {
            int nextLevelNumber = _currentLevel.Value?.LevelNumber + 1 ?? 1;
            var rewards = GenerateRewards();
            _currentLevel.Value = new LevelData(nextLevelNumber, rewards);
        }

        private List<RewardData> GenerateRewards()
        {
            var list = new List<RewardData>();
            var rewardOptions = _mainSettings.GetRandRewardOptions(UnityEngine.Random.Range(1, 6));
            
            foreach (var rewardOption in rewardOptions)
            {
                list.Add(new RewardData(rewardOption.RewardName, rewardOption.Amount.InRangeValue()));
            }

            return list;
        }
    }
}