using System;

namespace Project.UI
{
    public interface IWindow
    {
        public bool IsPopup { get; }

        void Init();
        void Show();
        void Hide();
    }
}
