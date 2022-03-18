using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using ZXing.QrCode.Internal;

public class GetQrRecognition : MonoBehaviour
{
    IBarcodeReader reader;
    private string text;
    Texture2D texture;

    // Start is called before the first frame update
    private void Start()
    {
        reader = new BarcodeReader();
    }

    public Texture2D GetTexture2DFromQrPhoto(WebCamTexture image)
    {
        //var result = reader.Decode(, image.width, image.height);
        //var result = reader.Decode(texture.EncodeToJPG(), image.width, image.height, RGBLuminanceSource.BitmapFormat.RGB24);
        // do something with the result
        //We reset before we decode for safety;

        Texture2D texture = new Texture2D(image.width, image.height, TextureFormat.ARGB32, false);

        texture.SetPixels32(image.GetPixels32());
        Result result = reader.Decode(texture.GetRawTextureData(), image.width, image.height, RGBLuminanceSource.BitmapFormat.ARGB32);
        if (result != null)
        {
            text = result.Text;
        }


        return texture;
    }

    public string GetQrTextFound()
    {
        return text;
    }



}
