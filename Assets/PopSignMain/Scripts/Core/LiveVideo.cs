using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveVideo : MonoBehaviour {

    private bool camAvailable;
    private WebCamTexture frontCam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;


    void Start() {

        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0) {
            Debug.Log("No cameras detected");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++) {
            if (devices[i].isFrontFacing) {
                frontCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (frontCam == null) {
            Debug.Log("Cannot find front facing camera");
            return;
        }

        // yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

         if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.Log("webcam found");
            frontCam.Play();
            background.texture = frontCam;

            camAvailable = true;
            
        }

        

    }

    void Update() {

        // if(!camAvailable) {
        //     return;
        // }

        // float ratio = (float)frontCam.width / (float)frontCam.height;

        // fit.aspectRatio = ratio;

        // float scaleY = frontCam.videoVerti

    }

}