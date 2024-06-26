using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Change Look Direction:
///     Changes Look Cursor depending on the player's input.
///     This is important so the player knows where to go when platforming.
///     This is the object the Cinemachine Camera is looking at.
/// @author: Juan Pablo Amorocho - 301410163
/// </summary>
public class ChangeLookDirection : MonoBehaviour
{
    [Tooltip("Will the object move in this axis?  ")]
    [SerializeField]
    private bool moveX, moveY;
    [Tooltip("Will X reset to origin value (0) when axis is not being hold.  ")]
    [SerializeField]
    private bool xReset;
    [Tooltip("Will Y reset to origin value (0) when axis is not being hold.  ")]
    [SerializeField]
    private bool yReset;

    [Tooltip("Bounds of the movement. ")]
    [SerializeField]
    private Vector2 bounds;

    // local calculations of bounds which depends on "looking direction".
    private Vector2 localBounds;

    private void Start()
    {
        localBounds = transform.localPosition;
    }
    public void MoveLookaround(Vector2 direction)
    {
        bool hasMoved = false;
        if (moveX)
        {
            hasMoved = true;
            if (!xReset)
            {
                if (direction.x != 0)
                    localBounds.x = bounds.x * direction.x;
            }
            else
            {
                localBounds.x = bounds.x * direction.x;
            }
        }
        if (moveY)
        {
            hasMoved = true;
            if (!yReset)
            {
                if (direction.y != 0)
                    localBounds.y = bounds.y * direction.y;
            }
            else
            {
                localBounds.y = bounds.y * direction.y;
            }
        }
        if (hasMoved)
        {
            transform.localPosition = localBounds;
        }
    }
}
