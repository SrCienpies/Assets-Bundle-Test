using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundle : MonoBehaviour
{

    public static LoadAssetBundle instance;


    [Header("Futbolista")]
    public string nombreFutbolista;
    public string url1 = "https://drive.google.com/uc?export=download&id=1VCOAtvU4dA7--OHDLeLnxvo2KkKaxQeT";
    [Header("Background")]
    public string nombreBackground;
    public string url2 = "https://drive.google.com/uc?export=download&id=1VCOAtvU4dA7--OHDLeLnxvo2KkKaxQeT";
    [Header("Musica")]
    public string nombreMusica;
    public string url3 = "https://drive.google.com/uc?export=download&id=1VCOAtvU4dA7--OHDLeLnxvo2KkKaxQeT";

    private WWW www1;
    private WWW www2;
    private WWW www3;

    public AudioClip clip;
    public AudioSource sourceMusica;

    private void Start()
    {
        www1 = new WWW(url1);
        www2 = new WWW(url2);
        www2 = new WWW(url3);

        sourceMusica = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) StartCoroutine(webReq(www1, nombreFutbolista));
        if (Input.GetKeyDown(KeyCode.E)) StartCoroutine(webReq(www2, nombreBackground));
        if (Input.GetKeyDown(KeyCode.R)) StartCoroutine(webReqAudioClip(www3));
    }

    IEnumerator webReq(WWW www, string name)
    {
        yield return www;

        while (www.isDone == false)
        {
            yield return null;
        }

        AssetBundle bundle = www.assetBundle;

        if(www.error == null)
        {
            GameObject obj = (GameObject)bundle.LoadAsset(name);
            Instantiate(obj);
        }
        else
        {
            print(www.error);
        }
    }

    IEnumerator webReqAudioClip(WWW request)
    {
        print("Paso 1");
        yield return request;
        //WWW request = WWW.LoadFromCacheOrDownload(url3,0);
        print("Paso 2");

        while (request.isDone == false)
        {
            yield return null;
        }

        print("Paso 3");

        AssetBundle bundle = request.assetBundle;

        print("Paso 4");

        if (request.error == null)
        {
            //AudioClip obj = (AudioClip)bundle.LoadAsset(nombreMusica);
            print("ENCONTRO ARCHIVO");
            clip = bundle.LoadAsset<AudioClip>(nombreMusica);
            //sourceMusica.clip = obj;
        }
        else
        {
            print("ERROR");
            print(request.error);
        }
    }
}
