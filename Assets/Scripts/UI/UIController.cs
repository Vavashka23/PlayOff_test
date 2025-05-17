using System;
using System.Linq;
using UnityEngine;

namespace Project.UI
{
    public class UIController : MonoBehaviour
    {
        private IWindow[] _windows;

        private void Awake()
        {
            var windows = GetComponentsInChildren<IWindow>(true);
            _windows = windows;

            foreach (var window in windows)
            {
                window.Init();
                window.Hide();
            }
            
            ShowWindow<MainWindow>();
        }

        public void ShowWindow<T>() where T : IWindow
        {
            var window = GetWindow<T>();
            
            if (!window.IsPopup)
            {
                HideAll();
            }
            
            window.Show();
        }

        private void HideAll()
        {
            foreach (var wnd in _windows)
            {
                wnd.Hide();
            }
        }

        private IWindow GetWindow<T>() where T : IWindow
        {
            var window = _windows.FirstOrDefault(w => w is T);

            if (window == null)
            {
                Debug.LogException(new Exception($"{typeof(T)} not found!"));
            }

            return window;
        }
    }
}
