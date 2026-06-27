using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.Exceptions;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace CodeBase.Runtime.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _assetRequests = new();

        public async UniTask InitializeAsync() =>
            await Addressables.InitializeAsync().ToUniTask();

        public async UniTask<TAsset> Load<TAsset>(string address) where TAsset : class
        {
            if (_assetRequests.TryGetValue(address, out AsyncOperationHandle handle) == false)
            {
                handle = Addressables.LoadAssetAsync<TAsset>(address);
                _assetRequests.Add(address, handle);
            }

            try
            {
                await handle.ToUniTask();

                if (handle.Status == AsyncOperationStatus.Failed &&
                    handle.OperationException is RemoteProviderException remoteException)
                    throw new Exception($"Asset loading error: {remoteException}");

                return handle.Result as TAsset;
            }
            catch (Exception ex)
            {
                throw new Exception($"Asset loading error at '{address}': {ex.Message}", ex);
            }
        }

        public async UniTask<TAsset> Load<TAsset>(AssetReference assetReference) where TAsset : class =>
            await Load<TAsset>(assetReference.AssetGUID);

        public async UniTask<TAsset[]> LoadAll<TAsset>(List<string> keys) where TAsset : class
        {
            List<UniTask<TAsset>> tasks = new(keys.Count);

            foreach (string key in keys)
                tasks.Add(Load<TAsset>(key));

            return await UniTask.WhenAll(tasks);
        }

        public async UniTask<List<string>> GetAssetsListByLabel<TAsset>(string label) =>
            await GetAssetsListByLabel(label, typeof(TAsset));

        public async UniTask<List<string>> GetAssetsListByLabel(string label, Type type = null)
        {
            AsyncOperationHandle<IList<IResourceLocation>> operationHandle =
                Addressables.LoadResourceLocationsAsync(label, type);

            IList<IResourceLocation> locations = await operationHandle.ToUniTask();

            List<string> assetKeys = new(locations.Count);

            foreach (IResourceLocation location in locations)
                assetKeys.Add(location.PrimaryKey);

            Addressables.Release(operationHandle);
            return assetKeys;
        }

        public async UniTask WarmupAssetsByLabel(string label)
        {
            List<string> assetsList = await GetAssetsListByLabel(label);
            await LoadAll<object>(assetsList);
        }

        public async UniTask ReleaseAssetsByLabel(string label)
        {
            List<string> assetsList = await GetAssetsListByLabel(label);

            foreach (string assetKey in assetsList)
                ReleaseAssetAndRequest(assetKey);
        }

        public void ReleaseAsset(string address) =>
            ReleaseAssetAndRequest(address);

        public void ReleaseAsset(AssetReference address) =>
            ReleaseAssetAndRequest(address.AssetGUID);

        public void ReleaseAll()
        {
            foreach (KeyValuePair<string, AsyncOperationHandle> assetRequest in _assetRequests)
                Addressables.Release(assetRequest.Value);

            _assetRequests.Clear();
        }

        private void ReleaseAssetAndRequest(string address)
        {
            if (_assetRequests.TryGetValue(address, out AsyncOperationHandle handler) == false)
                return;

            Addressables.Release(handler);
            _assetRequests.Remove(address);
        }
    }
}