using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour {
    public float minimumTurningSpeed = 0.41f;
    public float driftAngularDragReduction = 2.5f;

    public float accelleration = 0.5f;
    public float turningTorque = 0.5f;
    public float turningTorqueDuringDrift = 1.4f;

    public int playerNumber;

    private Rigidbody2D carRigidBody2D;

    private bool _shouldMove = true;
    public bool shouldMove
    {
        get
        {
            return _shouldMove;
        }
        set
        {
            _shouldMove = value;
        }
    }

    private float originalAngularDrag;
    private string horizontalAxisString;
    private string verticalAxisString;
    private string driftButtonString;
    private EffectsManagerComponent effectsManager;


    // Use this for initialization
    void Start () {
        carRigidBody2D = GetComponent<Rigidbody2D>();
        effectsManager = GetComponent<EffectsManagerComponent>();
        
        horizontalAxisString = "Horizontal Player " + playerNumber;
        verticalAxisString = "Vertical Player " + playerNumber;
        driftButtonString = "Drift Player " + playerNumber;
        originalAngularDrag = carRigidBody2D.angularDrag;
    }
	
	// Update is called once per frame
	void Update () {
        if (shouldMove)
        {
            Vector2 accellerationVector = transform.up * accelleration;
            carRigidBody2D.AddForce(accellerationVector * Input.GetAxis(verticalAxisString));
            if (carRigidBody2D.velocity.magnitude >= minimumTurningSpeed)
                if (Input.GetAxis(driftButtonString) == 1)
                {
                    carRigidBody2D.angularDrag = originalAngularDrag - driftAngularDragReduction;
                    carRigidBody2D.AddTorque(turningTorqueDuringDrift * -Input.GetAxis(horizontalAxisString));
                    effectsManager.EnableDriftEffect();
                }
                else
                {
                    carRigidBody2D.AddTorque(turningTorque * -Input.GetAxis(horizontalAxisString));
                    effectsManager.DisableDriftEffect();
                }
        }
    }
}
