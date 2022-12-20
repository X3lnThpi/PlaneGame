using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTrail : MonoBehaviour
{
    // The LineRenderer component for rendering the trail
    public LineRenderer lineRenderer;

    // The duration over which to fade the trail
    public float fadeDuration;

    // The maximum number of points to store in the trail
    public int maxPoints;

    // The list of points in the trail
    private List<Vector3> points;

    // The time at which the trail was last updated
    private float lastUpdateTime;

    void Start()
    {
        // Initialize the list of points
        points = new List<Vector3>();

        // Set the last update time to the current time
        lastUpdateTime = Time.time;

        // Start the FadeTrail coroutine
        StartCoroutine(FadeTrail());
    }

    void Update()
    {
        // Update the trail every frame
        UpdateTrail();
    }

    void UpdateTrail()
    {
        // Check if it's time to update the trail
        if (Time.time - lastUpdateTime >= 1f / 60f)
        {
            // It's time to update the trail

            // Add the current position to the list of points
            points.Add(transform.position);

            // Check if the list of points is too long
            if (points.Count > maxPoints)
            {
                // Remove the oldest point from the list
                points.RemoveAt(0);
            }

            // Set the line renderer's position and point count
            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPositions(points.ToArray());

            // Set the last update time to the current time
            lastUpdateTime = Time.time;
        }
    }

    IEnumerator FadeTrail()
    {
        // Fade the trail over time
        while (true)
        {
            // Wait for the specified fade duration
            yield return new WaitForSeconds(fadeDuration);

            // Decrease the alpha value of the line renderer's color
            Color color = lineRenderer.startColor;
            color.a -= 0.1f;
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;

            // Check if the alpha value has reached zero
            if (color.a <= 0f)
            {
                // The alpha value has reached zero, so stop the coroutine
                break;
            }
        }
    }
}
