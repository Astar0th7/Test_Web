using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game.Scripts.Root.Services.AssetsLoader
{
    public class LocalAssetLoader : ILocalAssetLoader
    {
        public async Task<T> LoadAssetById<T>(string assetId)
        {
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(assetId);
            await handle.Task;
            T result = handle.Result;
            handle.Release();
            return result;
        }

        public async Task<IList<T>> LoadAssetsByLabel<T>(string labelKey)
        {
            AsyncOperationHandle<IList<T>> handle = Addressables.LoadAssetsAsync<T>(labelKey, null);
            await handle.Task;
            IList<T> result = handle.Result;
            handle.Release();
            return result;
        }
    }
}