using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class BundleObjectLoader : MonoBehaviour
{

    public string assetPath = "Data/Oeste/Arti/Imagens/03.jpg", bundleName = "testebundle";

    public Image testeImageComponent;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        AssetBundleCreateRequest localBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName));

        yield return localBundleRequest;

        AssetBundle localBundle = localBundleRequest.assetBundle;

        if(localBundle == null) {

            Debug.LogError("Failed to load");
            yield break;

        }

        AssetBundleRequest assetRequest = localBundle.LoadAssetAsync<Sprite>(assetPath);
        yield return assetRequest;

        

        Sprite testeSprite = assetRequest.asset as Sprite;

        testeImageComponent.sprite = testeSprite;

        Debug.Log("terminou o start");

        //localBundle.Unload(false);
    }
}
