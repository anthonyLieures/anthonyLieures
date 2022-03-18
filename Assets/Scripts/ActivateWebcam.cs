using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateWebcam : MonoBehaviour
{
   
    public RawImage imageWebcam;
    WebCamTexture webCamTexture;

    public void StartLaunch()
    {
        WebCamDevice[] cam_devices = WebCamTexture.devices;
        webCamTexture = new WebCamTexture(cam_devices[0].name, 1920, 1080, 60);

        CapturePhoto();
    }


    void Update()
    {
        if (webCamTexture != null)
        {
            imageWebcam.texture = webCamTexture;
            imageWebcam.material.mainTexture = webCamTexture;
        }
    }

    public void CapturePhoto()
    {
        webCamTexture.Play();
    }

    public WebCamTexture GetWebCamTexture()
    {
        return webCamTexture;
    }

    public RawImage GetRawImage()
    {
        return imageWebcam;
    }


}
