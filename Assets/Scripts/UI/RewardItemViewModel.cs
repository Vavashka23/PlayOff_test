using System.Collections;
using System.Collections.Generic;
using Project.Datas;
using TMPro;
using UnityEngine;

namespace Project.UI
{
    public class RewardItemViewModel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void Setup(RewardData data)
        {
            _text.text = data.ToString();
        }
    }
}
