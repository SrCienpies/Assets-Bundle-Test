using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class BundleWebLoader : MonoBehaviour
{
    public string bundleUrl = "http://localhost/assetbundles/testbundle";
    public string assetName = "BundledObject";


    //public Texture2D sprite;
    public AudioClip clip;
    public AudioSource source;
    public SpriteRenderer sprite;


    IEnumerator Start()
    {
        using (WWW web = new WWW(bundleUrl))
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if (remoteAssetBundle == null)
            {
                Debug.LogError("Failed to download AssetBundle!");
                yield break;
            }

            clip = (AudioClip)remoteAssetBundle.LoadAsset(assetName);

            //Texture2D tx = (Texture2D)remoteAssetBundle.LoadAsset(assetName);
            //sprite.sprite = ConvertToSpriteExtensiton.ConvertToSprite(tx);
            source.clip = clip;
            source.Play();
            remoteAssetBundle.Unload(false);
        }
    }
}