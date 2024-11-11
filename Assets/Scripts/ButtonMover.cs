using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMover : MonoBehaviour
{
    // Speed at which the button moves
    public float moveSpeed = 500f;
    // Time interval for generating random positions
    public float moveInterval = 1f;

    // Movement range for X and Y coordinates within the Canvas
    private float canvasWidth;
    private float canvasHeight;

    private RectTransform canvasRectTransform;
    private Vector3 targetPosition;
    private float timeSinceLastMove;

    public GameObject correctWordButton;

    public DogGameController dogGameController;


    void Start()
    {
        // Get the Canvas RectTransform component
        canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();

        // Calculate the Canvas size in world units
        canvasWidth = canvasRectTransform.rect.width;
        canvasHeight = canvasRectTransform.rect.height;

        // Start by setting the initial target position
        SetRandomTargetPosition();
    }

    void Update()
    {
        // Track time and move to the new target when the interval is reached
        timeSinceLastMove += Time.deltaTime;

        if (timeSinceLastMove >= moveInterval)
        {
            timeSinceLastMove = 0f;
            SetRandomTargetPosition();
        }

        // Move the button towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

         if (dogGameController != null && dogGameController.IsCorrectWordSelected()) // Calling the method from DogGameController
        {
            correctWordButton.SetActive(false); // Hide the button
        }
    }

    // Function to set a new random target position within the Canvas boundaries
    void SetRandomTargetPosition()
    {
        // Get the Canvas world position (position of the top-left corner of the Canvas)
        Vector3 canvasWorldPos = canvasRectTransform.position;

        // Calculate random positions within the Canvas bounds
        float randomX = Random.Range(canvasWorldPos.x - canvasWidth / 2, canvasWorldPos.x + canvasWidth / 2);
        float randomY = Random.Range(canvasWorldPos.y - canvasHeight / 2, canvasWorldPos.y + canvasHeight / 2);

        // Set the new target position
        targetPosition = new Vector3(randomX, randomY, transform.position.z);
    }

    
}
