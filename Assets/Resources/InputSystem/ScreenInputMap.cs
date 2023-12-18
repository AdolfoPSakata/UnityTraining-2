//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Resources/InputSystem/ScreenInputMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace UnityEngine.InputSystem
{
    public partial class @ScreenInputMap: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ScreenInputMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ScreenInputMap"",
    ""maps"": [
        {
            ""name"": ""ScreenInput"",
            ""id"": ""681af043-a2fb-4c2f-86da-00914f379e18"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""a1500d44-6f08-459f-b6e9-0869d68e7c08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.1,pressPoint=0.1)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""UI"",
                    ""type"": ""Button"",
                    ""id"": ""a2e0f817-4460-4143-a0d5-89947ee982dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)"",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""040d1fb7-bb29-4784-86f5-50dec5436d1f"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": ""Tap(duration=0.1,pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40e12a18-bd6f-4365-8d40-defb9aadafee"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": ""Press(pressPoint=0.1),Tap(duration=0.1,pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""UI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // ScreenInput
            m_ScreenInput = asset.FindActionMap("ScreenInput", throwIfNotFound: true);
            m_ScreenInput_Tap = m_ScreenInput.FindAction("Tap", throwIfNotFound: true);
            m_ScreenInput_UI = m_ScreenInput.FindAction("UI", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // ScreenInput
        private readonly InputActionMap m_ScreenInput;
        private List<IScreenInputActions> m_ScreenInputActionsCallbackInterfaces = new List<IScreenInputActions>();
        private readonly InputAction m_ScreenInput_Tap;
        private readonly InputAction m_ScreenInput_UI;
        public struct ScreenInputActions
        {
            private @ScreenInputMap m_Wrapper;
            public ScreenInputActions(@ScreenInputMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @Tap => m_Wrapper.m_ScreenInput_Tap;
            public InputAction @UI => m_Wrapper.m_ScreenInput_UI;
            public InputActionMap Get() { return m_Wrapper.m_ScreenInput; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ScreenInputActions set) { return set.Get(); }
            public void AddCallbacks(IScreenInputActions instance)
            {
                if (instance == null || m_Wrapper.m_ScreenInputActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_ScreenInputActionsCallbackInterfaces.Add(instance);
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
                @UI.started += instance.OnUI;
                @UI.performed += instance.OnUI;
                @UI.canceled += instance.OnUI;
            }

            private void UnregisterCallbacks(IScreenInputActions instance)
            {
                @Tap.started -= instance.OnTap;
                @Tap.performed -= instance.OnTap;
                @Tap.canceled -= instance.OnTap;
                @UI.started -= instance.OnUI;
                @UI.performed -= instance.OnUI;
                @UI.canceled -= instance.OnUI;
            }

            public void RemoveCallbacks(IScreenInputActions instance)
            {
                if (m_Wrapper.m_ScreenInputActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IScreenInputActions instance)
            {
                foreach (var item in m_Wrapper.m_ScreenInputActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_ScreenInputActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public ScreenInputActions @ScreenInput => new ScreenInputActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        private int m_TouchSchemeIndex = -1;
        public InputControlScheme TouchScheme
        {
            get
            {
                if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
                return asset.controlSchemes[m_TouchSchemeIndex];
            }
        }
        private int m_JoystickSchemeIndex = -1;
        public InputControlScheme JoystickScheme
        {
            get
            {
                if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
                return asset.controlSchemes[m_JoystickSchemeIndex];
            }
        }
        private int m_XRSchemeIndex = -1;
        public InputControlScheme XRScheme
        {
            get
            {
                if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
                return asset.controlSchemes[m_XRSchemeIndex];
            }
        }
        public interface IScreenInputActions
        {
            void OnTap(InputAction.CallbackContext context);
            void OnUI(InputAction.CallbackContext context);
        }
    }
}
