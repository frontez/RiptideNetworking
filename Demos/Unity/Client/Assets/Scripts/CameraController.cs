﻿
// This file is provided under The MIT License as part of RiptideNetworking.
// Copyright (c) 2021 Tom Weiland
// For additional information please see the included LICENSE.md file or view it on GitHub: https://github.com/tom-weiland/RiptideNetworking/blob/main/LICENSE.md

using UnityEngine;

namespace RiptideNetworking.Demos.RudpTransport.Unity.ExampleClient
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private float sensitivity = 100f;
        [SerializeField] private float clampAngle = 85f;

        private float verticalRotation;
        private float horizontalRotation;

        private void Start()
        {
            verticalRotation = transform.localEulerAngles.x;
            horizontalRotation = player.transform.eulerAngles.y;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                ToggleCursorMode();

            if (Cursor.lockState == CursorLockMode.Locked)
                Look();

            Debug.DrawRay(transform.position, transform.forward * 2, Color.green);
        }

        private void Look()
        {
            float mouseVertical = -Input.GetAxis("Mouse Y");
            float mouseHorizontal = Input.GetAxis("Mouse X");

            verticalRotation += mouseVertical * sensitivity * Time.deltaTime;
            horizontalRotation += mouseHorizontal * sensitivity * Time.deltaTime;

            verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

            transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
            player.transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);
        }

        private void ToggleCursorMode()
        {
            Cursor.visible = !Cursor.visible;

            if (Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
        }
    }
}