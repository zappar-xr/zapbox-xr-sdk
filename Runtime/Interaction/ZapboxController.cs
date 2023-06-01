using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.XR;

#if UNITY_EDTIOR
using UnityEditor;
using UnityEditor.Build;
#endif

namespace Zappar
{

    // This input layout was written with reference to Unity's generic terminology and the Oculus Touch
    // definition. We generally go with the terms used in the Oculus Touch definition (ie gripPressed)
    // as those seem to be the names used in the XR Interaction Framework defaults. The strings defined
    // in XR.CommonUsages (eg gripButton) are listed as aliases.

    public class ZapboxControllerProfile
    {
        /// <summary>
        /// A Zapbox Controller.
        /// </summary>
        [Preserve]
        [InputControlLayout(displayName = "Zapbox Controller", commonUsages = new[] { "LeftHand", "RightHand" })]
        public class ZapboxController : XRController
        {
            [Preserve, InputControl(aliases = new[] { "primary2DAxis", "joystick" })]
            public Vector2Control thumbstick { get; private set; }

            [Preserve, InputControl]
            public AxisControl trigger { get; private set; }
            [Preserve, InputControl]
            public AxisControl grip { get; private set; }

            [Preserve, InputControl(aliases = new[] { "A", "X" })]
            public ButtonControl primaryButton { get; private set; }
            [Preserve, InputControl(aliases = new[] { "B", "Y" })]
            public ButtonControl secondaryButton { get; private set; }
            [Preserve, InputControl(aliases = new[] { "menuButton", "systemButton", "start" })]
            public ButtonControl menu { get; private set; }

            [Preserve, InputControl(aliases = new[] { "primary2DAxisClick", "joystickOrPadPressed", "thumbstickClick" })]
            public ButtonControl thumbstickClicked { get; private set; }
            [Preserve,InputControl(aliases = new[] { "triggerButton", "indexButton" })]
            public ButtonControl triggerPressed { get; private set; }
            [Preserve, InputControl(aliases = new[] { "gripButton" })]
            public ButtonControl gripPressed { get; private set; }

            [Preserve, InputControl(aliases = new[] { "controllerTrackingState" })]
            public new IntegerControl trackingState { get; private set; }
            [Preserve, InputControl(aliases = new[] { "controllerIsTracked" })]
            public new ButtonControl isTracked { get; private set; }
            [Preserve, InputControl(aliases = new[] { "controllerPosition" })]
            public new Vector3Control devicePosition { get; private set; }
            [Preserve, InputControl(aliases = new[] { "controllerRotation" })]
            public new QuaternionControl deviceRotation { get; private set; }
            [Preserve, InputControl(aliases = new[] { "controllerVelocity" })]
            public Vector3Control deviceVelocity { get; private set; }

            protected override void FinishSetup()
            {
                base.FinishSetup();

                thumbstick = GetChildControl<Vector2Control>("thumbstick");
                trigger = GetChildControl<AxisControl>("trigger");
                grip = GetChildControl<AxisControl>("grip");

                primaryButton = GetChildControl<ButtonControl>("primaryButton");
                secondaryButton = GetChildControl<ButtonControl>("secondaryButton");
                menu = GetChildControl<ButtonControl>("menu");
                
                thumbstickClicked = GetChildControl<ButtonControl>("thumbstickClicked");
                triggerPressed = GetChildControl<ButtonControl>("triggerPressed");
                gripPressed = GetChildControl<ButtonControl>("gripPressed");

                trackingState = GetChildControl<IntegerControl>("trackingState");
                isTracked = GetChildControl<ButtonControl>("isTracked");
                devicePosition = GetChildControl<Vector3Control>("devicePosition");
                deviceRotation = GetChildControl<QuaternionControl>("deviceRotation");
                deviceVelocity = GetChildControl<Vector3Control>("deviceVelocity");
            }

        }
    }
}