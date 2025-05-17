using Project.Datas;
using UniRx;

namespace Project.Services
{
    public interface ILevelService
    {
        IReadOnlyReactiveProperty<LevelData> CurrentLevel { get; }
        
        void GenerateNextLevel();
    }
}
