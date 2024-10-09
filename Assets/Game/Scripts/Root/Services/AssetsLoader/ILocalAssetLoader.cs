using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Scripts.Root.Services.AssetsLoader
{
    public interface ILocalAssetLoader
    {
        Task<T> LoadAssetById<T>(string assetId);
        Task<IList<T>> LoadAssetsByLabel<T>(string labelKey);
    }
}