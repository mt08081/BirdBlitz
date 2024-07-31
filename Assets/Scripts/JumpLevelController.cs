using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLevelController : MonoBehaviour
{
    public GameObject topStripPrefab;
    public GameObject bottomStripPrefab;
    public float levelSpeed = 5.0f;
    public float stripWidth = 10.0f; // Width of your strip prefab
    private List<GameObject> topStrips = new List<GameObject>();
    private List<GameObject> bottomStrips = new List<GameObject>();
    private Camera mainCamera;
    private float screenWidthInWorldUnits;

    void Start()
    {
        mainCamera = Camera.main;
        screenWidthInWorldUnits = mainCamera.orthographicSize * 2.0f * Screen.width / Screen.height;

        // Initialize the strips
        InitializeStrips();
    }

    void Update()
    {
        // Move all strips to the left
        foreach (GameObject strip in topStrips)
        {
            strip.transform.Translate(Vector3.left * levelSpeed * Time.deltaTime);
        }
        foreach (GameObject strip in bottomStrips)
        {
            strip.transform.Translate(Vector3.left * levelSpeed * Time.deltaTime);
        }

        // Check if we need to add a new strip and remove old strips
        if (NeedNewStrip())
        {
            AddNewStrip();
        }
        RemoveOldStrips();
    }

    void InitializeStrips()
    {
        // Create initial strips to fill the screen
        for (float x = 0; x < screenWidthInWorldUnits + stripWidth; x += stripWidth)
        {
            AddStripAtPosition(x);
        }
    }

    bool NeedNewStrip()
    {
        // Check if the rightmost strip is near the edge of the screen
        float rightmostStripX = topStrips[topStrips.Count - 1].transform.position.x;
        return rightmostStripX < mainCamera.transform.position.x + screenWidthInWorldUnits / 2;
    }

    void AddNewStrip()
    {
        // Add a new strip at the right edge
        float newX = topStrips[topStrips.Count - 1].transform.position.x + stripWidth;
        AddStripAtPosition(newX);
    }

    void AddStripAtPosition(float x)
    {
        // Instantiate top and bottom strips at the specified x position
        Vector3 topPosition = new Vector3(x, 5.0f, 0.0f); // Adjust y position as needed
        Vector3 bottomPosition = new Vector3(x, -5.0f, 0.0f); // Adjust y position as needed
        GameObject newTopStrip = Instantiate(topStripPrefab, topPosition, Quaternion.identity);
        GameObject newBottomStrip = Instantiate(bottomStripPrefab, bottomPosition, Quaternion.identity);
        topStrips.Add(newTopStrip);
        bottomStrips.Add(newBottomStrip);
    }

    void RemoveOldStrips()
    {
        // Remove strips that are out of the camera view
        float leftEdgeX = mainCamera.transform.position.x - screenWidthInWorldUnits / 2;
        if (topStrips[0].transform.position.x < leftEdgeX - stripWidth)
        {
            Destroy(topStrips[0]);
            Destroy(bottomStrips[0]);
            topStrips.RemoveAt(0);
            bottomStrips.RemoveAt(0);
        }
    }
}
