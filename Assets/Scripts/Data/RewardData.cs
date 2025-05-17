using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Datas
{
    public class RewardData
    {
        public string Name { get; }
        public int Amount { get; }

        public RewardData(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }

        public override string ToString() => $"{Name} x{Amount}";
    }
}