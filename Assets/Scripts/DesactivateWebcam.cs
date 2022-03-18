using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesactivateWebcam : MonoBehaviour
{
    public RawImage imageWebcam;
    public GameObject webcam;

    // Start is called before the first frame update
    public void StopCapture()
    {
        GetComponent<ActivateWebcam>().GetWebCamTexture().Stop();
        webcam.SetActive(false);
    }
}
