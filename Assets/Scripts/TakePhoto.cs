
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{
    // dossier de sauvegarde d'une capture
    public readonly string pathSave = "captures/basic";
    public readonly int maxImageSave = 3;

    public RawImage imageWebcam;
    ActivateWebcam activateWebcam;
    public InputField inputText;

    public GameObject WordPopup;
    public GameObject wordPrefab;
    public Transform scrollContent;

    // Start is called before the first frame update
    void Start()
    {
        activateWebcam = GetComponent<ActivateWebcam>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    List<string> GetButtonsTextPopup()
    {
        Button[] btns = scrollContent.GetComponentsInChildren<Button>();
        List<string> res = new List<string>();
        foreach (Button btn in btns)
        {
            res.Add(btn.GetComponentInChildren<Text>().text);
        }
        return res;
    }
    void AddTextToInput(String text)
    {
        inputText.text += text;
    }

    public void HandleCapture()
    {
        GetTextRecognition recognition = GetComponent<GetTextRecognition>();
        GetQrRecognition qrRecognition = GetComponent<GetQrRecognition>();
        Texture2D textu = recognition.GetTextFromImage(activateWebcam.GetWebCamTexture());
        SaveTextureAsPNG(textu);
        textu.EncodeToPNG();
        qrRecognition.GetTexture2DFromQrPhoto(activateWebcam.GetWebCamTexture());
        string qrTextFound = qrRecognition.GetQrTextFound();
        inputText.text = qrTextFound != null ? qrTextFound : "";
        object[] wordsFound = recognition.GetTableWords();
        if (wordsFound.Length > 0)
        {
            List<string> existingWords = GetButtonsTextPopup();
            foreach (Dictionary<string, object> founded in recognition.GetTableWords())
            {
                if (founded != null && !existingWords.Contains((string)founded["word"]))
                {
                    GameObject word = Instantiate(wordPrefab);

                    string wordString = (string)founded["word"];
                    word.GetComponentInChildren<Text>().text = wordString + "";
                    word.GetComponentInChildren<Button>().onClick.AddListener(() => AddTextToInput(wordString));
                    word.transform.SetParent(scrollContent);
                }
                if (!WordPopup.activeSelf) WordPopup.SetActive(true);
            }
            
        }
    }

    // TODO : Fichier config ( path )

    private void SaveTextureAsPNG(Texture2D texture)
    {
        byte[] itemBGBytes = texture.EncodeToPNG();

        // Si le directory n'existe pas on le crée
        if (!Directory.Exists(pathSave))
        {
            Directory.CreateDirectory(pathSave);
        }

        // Listing des paths des images du dossier
        List<string> images = new List<string>(Directory.GetFiles(pathSave, "*.png"));
        images.Sort();

        // Timestamp actuelle, unique à la milliseconde près
        string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");

        // Si il y a trop de photo on delete la plus ancienne qui est, de facto,
        // celle avec le timestamp le plus ancien
        if (images.Count > 0 && images.Count >= maxImageSave)
        {
            File.Delete(images[0]);
        }

        // Génération du fichier .png
        File.WriteAllBytes(pathSave + "/" + timeStamp + ".png", itemBGBytes);
    }
}
