using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
public class GetTextRecognition : MonoBehaviour
{
    private TesseractDriver driver;
    Texture2D texture;
    object dataTableWords;

    public void Start()
    {
        driver = new TesseractDriver();

    }

    public Texture2D GetTextFromImage(WebCamTexture image)
    {
        texture = GetTexture2DFromWebcamTexture(image);
        driver.Setup(OnDriverReady);
        return texture;
    }

    private void OnDriverReady()
    {
        // text = (string)driver.Recognize(texture);
        dataTableWords = driver.Recognize(texture,true);
    }

    public object[] GetTableWords()
    {
       ProcessRecognition processRecognition = GetComponent<ProcessRecognition>();
       return processRecognition.FormatTableWords(dataTableWords);
    }


    public Texture2D GetTexture2DFromWebcamTexture(WebCamTexture webCamTexture)
    {   
        Texture2D tx2d = new Texture2D(webCamTexture.width, webCamTexture.height);
        tx2d.SetPixels(webCamTexture.GetPixels());
        tx2d.Apply();
        return tx2d;
    }

}
