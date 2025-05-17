using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Datas
{
    public class LevelData
    {
        public int LevelNumber { get; }
        public IReadOnlyList<RewardData> Rewards { get; }

        public LevelData(int levelNumber, IReadOnlyList<RewardData> rewards)
        {
            LevelNumber = levelNumber;
            Rewards = rewards;
        }
    }
}