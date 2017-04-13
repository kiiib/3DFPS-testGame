﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animatorController;

    public Transform rotateYTransform;
    public Transform rotateXTransform;
    public float rotateSpeed;
    public float currentRotateX = 0;

	// Use this for initialization
	void Start () {
        animatorController = this.GetComponent<Animator>();
    }

    public float MoveSpeed;
    float currentSpeed = 0;

	// Update is called once per frame
	void Update () {
        float result = 0;

        if (Input.GetKey(KeyCode.W)) {
            result += MoveSpeed;
        }
        if (Input.GetKey(KeyCode.S)) {
            result -= MoveSpeed;
        }

        rotateYTransform.transform.localEulerAngles += new Vector3(0, Input.GetAxis("Horizontal"), 0) * rotateSpeed;
        currentRotateX += Input.GetAxis("Vertical") * rotateSpeed;


        currentSpeed = result;
        this.transform.position += Time.deltaTime * currentSpeed * this.transform.forward;

        animatorController.SetFloat("Speed", currentSpeed);
	}
}
