using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Rene.Sdk;

public class GetUserAssets : MonoBehaviour
{
    private async Task GetUserAssetsAsync(API reneApi)
    {
        AssetsResponse.AssetsData userAssets = await reneApi.Game().Assets();
        userAssets?.Items.ForEach
        (asset => Debug.Log
            ($" - Asset Id '{asset.NftId}' Name '{asset.Metadata.Name}"));
        userAssets?.Items.ForEach(asset =>
        {
            string assetName = asset.Metadata.Name;
            string assetImageUrl = asset.Metadata.Image;
            string assetStyle = "";
            asset.Metadata?.Attributes?.ForEach(attribute =>
            {
                if (attribute.TraitType == "Flight Boost")
                {
                    assetStyle = attribute.Value;
                }
            });
            Asset assetObj = new Asset(assetName, assetImageUrl, assetStyle);
            _assetManager.userAssets.Add(assetObj);
        });
    }
}
