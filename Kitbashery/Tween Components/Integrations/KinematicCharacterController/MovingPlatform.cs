using KinematicCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IMoverController
{
    public PhysicsMover Mover;

    public TweenTranslate translator;

    public TweenRotation rotator;

    private Vector3 _originalPosition;
    private Quaternion _originalRotation;

    public void UpdateMovement(out Vector3 goalPosition, out Quaternion goalRotation, float deltaTime)
    {
        if(translator != null)
        {
            goalPosition = translator.nextPos;
        }
        else
        {
            goalPosition = _originalPosition;
        }

        if(rotator != null)
        {
            goalRotation = rotator.nextRot;
        }
        else
        {
            goalRotation = _originalRotation;
        }
    }

    private void Start()
    {
        _originalPosition = Mover.Rigidbody.position;
        _originalRotation = Mover.Rigidbody.rotation;

        Mover.MoverController = this;
    }
}
