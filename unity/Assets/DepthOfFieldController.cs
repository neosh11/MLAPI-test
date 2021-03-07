using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering.PostProcessing;

public class DepthOfFieldController : MonoBehaviour
{

    private Camera _camera;
    private PostProcessVolume processVolume;
    private DepthOfField depthOfField;

    private float hitDistance;


    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        processVolume = GetComponent<PostProcessVolume>();
        processVolume.profile.TryGetSettings<DepthOfField>(out depthOfField);
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }


    // Update is called once per frame
    void Update()
    {

        // Raycasting


        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.
        pixelHeight / 2, 0);


        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            hitDistance = Vector3.Distance(transform.transform.position, hit.point);

        }
        else
        {
            // Nothing is hit
            hitDistance = 100f;
        }
        SetFocus();

    }

    void SetFocus()
    {
        depthOfField.focusDistance.value = hitDistance;
    }
}
