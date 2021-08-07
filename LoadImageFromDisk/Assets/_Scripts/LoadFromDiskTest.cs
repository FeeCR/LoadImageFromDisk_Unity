using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LoadFromDiskTest : MonoBehaviour
{
    public Image imgComponent;
    public VideoPlayer videoComponent;

    string pathToProjFolder;

    string videoInstructionPath = "ImagesReference/Data/Commons/Videos/manifesto_r.mp4", imageInstructionPath = "ImagesReference/Data/Oeste/Arti/Imagens/04.png";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TestLoad");
    }

    IEnumerator TestLoad () {


        //Seta a URL pra até antes de "nomeDoProjeto/Assets" || Set the URL to the path right before "projectName/Assets"
        pathToProjFolder = Application.dataPath;
        int maxIndex = pathToProjFolder.Length - 1;
        pathToProjFolder = pathToProjFolder.Remove(maxIndex - 23);


        string pathImagem = pathToProjFolder + imageInstructionPath;
        imgComponent.sprite = LoadSprite(pathImagem);

        Debug.Log("Loaded from disk " + pathImagem);

        string pathVideo = pathToProjFolder + videoInstructionPath;
        videoComponent.url = pathVideo;

        videoComponent.Prepare();

        while (!videoComponent.isPrepared) {
            yield return null;
        }

        videoComponent.Play();

        yield return null;

    }

    private Sprite LoadSprite (string path) {

        if (string.IsNullOrEmpty(path)) return null;

        if (System.IO.File.Exists(path)) {
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            return sprite;
        }
        return null;
    }

    
}
