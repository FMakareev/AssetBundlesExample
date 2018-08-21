using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBundle : MonoBehaviour {

    // Имя бандла
    public string BundleName;
    // Имя сцены
    public string SceneName;

    // Имя манифеста бандла
    public string ManifestName;

    // Манифест бандла
    AssetBundleManifest Manifest;

	// Use this for initialization
	IEnumerator Start () {

        // загружаем манифест бандла
        using (WWW www = new WWW("file://E:/UnityProjects/AssetBundlesExample/Data/" + ManifestName))
        {
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
                yield break;
            }
            print(www.assetBundle);
            // Получаем манифест из www 
            //Manifest = www.assetBundle.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
            Manifest = www.assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

            yield return null;

            // Выгружаем из ОЗУ 
            www.assetBundle.Unload(false);

        }

        // Получаем бандл, вторым аргументом передаем хеш из манифеста, сли хеш изменился то загрузится новый бандл если нет то загрузится и кеша
        using (WWW www = WWW.LoadFromCacheOrDownload("file://E:/UnityProjects/AssetBundlesExample/Data/"+ BundleName, Manifest.GetAssetBundleHash(BundleName)))
        {
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
                yield break;
            }

            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
            
            yield return null;

            www.assetBundle.Unload(true);

        }


	}
	
}
