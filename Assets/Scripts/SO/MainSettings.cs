using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Project.Settings
{
    [CreateAssetMenu(menuName = "SO Files/Main Settings")]
    public class MainSettings : ScriptableObject
    {
        [Serializable]
        public class RewardOption
        {
            public string RewardName;
            public IntRange Amount;
        }
        
        [Header("Rewards")]
        [SerializeField] private List<RewardOption> _rewardOptions = null;
        
        private Random _rng = new Random();

        public List<RewardOption> GetRandRewardOptions(int count)
        {
            if (count > _rewardOptions.Count)
                return _rewardOptions;
            
            var list = _rewardOptions.ToArray();

            return list
                .OrderBy(_ => _rng.Next())
                .Take(count)
                .ToList();
        }
    }
}
