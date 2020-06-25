// GENERATED AUTOMATICALLY FROM 'Assets/0_Main Project Folder/Player Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputAsset : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Input"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d687d2d3-09d0-4397-b860-cfff802a247f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6b5d6781-b49f-4232-b7ba-053b8099efb4"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookAround"",
                    ""type"": ""Value"",
                    ""id"": ""44f411a6-b0b0-4398-a088-19782087bdf0"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""ceafc844-10bd-488c-9ecc-7fde14e7fe42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""DropRelic"",
                    ""type"": ""Button"",
                    ""id"": ""e7eaabfd-d8bc-4eb1-96d4-4585c79bc26c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ThrowRelic"",
                    ""type"": ""Button"",
                    ""id"": ""e774fdcd-2170-4afb-927c-9d0d0e0583f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""dba4dc8c-73bd-41e5-8771-44047521d52f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ResetRelic"",
                    ""type"": ""Button"",
                    ""id"": ""8d76aa48-bf7b-49b1-a979-bfb26a583dfc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""CastPrimarySpell"",
                    ""type"": ""Button"",
                    ""id"": ""e0b2139a-3f2b-424a-8d70-0cb517278706"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""CastSecondarySpell"",
                    ""type"": ""Button"",
                    ""id"": ""cc35d9e0-da21-40c8-9173-cdeab3cbfd1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""OpenConsole"",
                    ""type"": ""Button"",
                    ""id"": ""92b36b4f-a015-4c0f-9bd2-9905965bbb68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""SubmitInput"",
                    ""type"": ""Button"",
                    ""id"": ""93ac8a59-d6bd-4405-9a3a-2dc99678cd1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""LastCommand"",
                    ""type"": ""Button"",
                    ""id"": ""6b69efe2-59d1-493d-a807-9c67a1c594ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b73f2c0a-0e4b-4875-8868-609dfb352ada"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16b53e9e-ae2b-4b92-b5b2-50f2a710c855"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fb20fea-638d-44c8-bd26-1419b4f4e83b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowRelic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d49e6f0-7f8e-4cff-a281-3cf689d5f9b1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropRelic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6665144-37e4-4cb7-b308-c544260ade33"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""256f206f-c7a8-41fb-a6c5-adf7efad6e5e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51449835-1990-4cdc-a8b9-2ee4d4d68c37"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetRelic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""558543b1-79fa-4e1d-80ce-89ce350c3add"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastPrimarySpell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4178b021-c13f-474e-b06e-0072b09edcb8"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastSecondarySpell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17001378-f8c1-48ab-a775-12a2157b097e"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenConsole"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""526971ad-8fb7-4fbd-9209-abaa82ca9917"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SubmitInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35532c4d-e289-4c5e-9d75-cb3cb5ab794c"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LastCommand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI Navigation"",
            ""id"": ""a36f2bf8-6389-4efb-b26c-fa9857f3e7d2"",
            ""actions"": [
                {
                    ""name"": ""MoveCursor"",
                    ""type"": ""Value"",
                    ""id"": ""7ca8f5b1-2e75-45d8-9e92-67889418bff9"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""5a267c94-de75-45cb-bf40-58bbe0d9912e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Start Game"",
                    ""type"": ""Button"",
                    ""id"": ""f704844b-6d96-4d19-91ab-33d19234279a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""CancelSelection"",
                    ""type"": ""Button"",
                    ""id"": ""baa91360-1423-4106-9d53-b5444975fda8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e3f82658-d354-4e56-bf54-75a449f74949"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2917aef-f0a3-44a0-8290-42a6f14b7889"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""383ac6eb-334f-4a80-8a27-803581f9da09"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c182f810-4802-4079-9d59-5d19fd273d60"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Sandstorm Sample Scene"",
            ""id"": ""bf4a7c5a-fb12-422e-a0da-4464058971a6"",
            ""actions"": [
                {
                    ""name"": ""CastSpell"",
                    ""type"": ""Button"",
                    ""id"": ""1864b438-8232-4f92-80c2-6edd6d0b3d7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7bdaf581-6953-414a-90cd-eb92506746de"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastSpell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_LookAround = m_Player.FindAction("LookAround", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_DropRelic = m_Player.FindAction("DropRelic", throwIfNotFound: true);
        m_Player_ThrowRelic = m_Player.FindAction("ThrowRelic", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_ResetRelic = m_Player.FindAction("ResetRelic", throwIfNotFound: true);
        m_Player_CastPrimarySpell = m_Player.FindAction("CastPrimarySpell", throwIfNotFound: true);
        m_Player_CastSecondarySpell = m_Player.FindAction("CastSecondarySpell", throwIfNotFound: true);
        m_Player_OpenConsole = m_Player.FindAction("OpenConsole", throwIfNotFound: true);
        m_Player_SubmitInput = m_Player.FindAction("SubmitInput", throwIfNotFound: true);
        m_Player_LastCommand = m_Player.FindAction("LastCommand", throwIfNotFound: true);
        // UI Navigation
        m_UINavigation = asset.FindActionMap("UI Navigation", throwIfNotFound: true);
        m_UINavigation_MoveCursor = m_UINavigation.FindAction("MoveCursor", throwIfNotFound: true);
        m_UINavigation_Confirm = m_UINavigation.FindAction("Confirm", throwIfNotFound: true);
        m_UINavigation_StartGame = m_UINavigation.FindAction("Start Game", throwIfNotFound: true);
        m_UINavigation_CancelSelection = m_UINavigation.FindAction("CancelSelection", throwIfNotFound: true);
        // Sandstorm Sample Scene
        m_SandstormSampleScene = asset.FindActionMap("Sandstorm Sample Scene", throwIfNotFound: true);
        m_SandstormSampleScene_CastSpell = m_SandstormSampleScene.FindAction("CastSpell", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_LookAround;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_DropRelic;
    private readonly InputAction m_Player_ThrowRelic;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_ResetRelic;
    private readonly InputAction m_Player_CastPrimarySpell;
    private readonly InputAction m_Player_CastSecondarySpell;
    private readonly InputAction m_Player_OpenConsole;
    private readonly InputAction m_Player_SubmitInput;
    private readonly InputAction m_Player_LastCommand;
    public struct PlayerActions
    {
        private @InputAsset m_Wrapper;
        public PlayerActions(@InputAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @LookAround => m_Wrapper.m_Player_LookAround;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @DropRelic => m_Wrapper.m_Player_DropRelic;
        public InputAction @ThrowRelic => m_Wrapper.m_Player_ThrowRelic;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @ResetRelic => m_Wrapper.m_Player_ResetRelic;
        public InputAction @CastPrimarySpell => m_Wrapper.m_Player_CastPrimarySpell;
        public InputAction @CastSecondarySpell => m_Wrapper.m_Player_CastSecondarySpell;
        public InputAction @OpenConsole => m_Wrapper.m_Player_OpenConsole;
        public InputAction @SubmitInput => m_Wrapper.m_Player_SubmitInput;
        public InputAction @LastCommand => m_Wrapper.m_Player_LastCommand;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @LookAround.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookAround;
                @LookAround.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookAround;
                @LookAround.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookAround;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @DropRelic.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropRelic;
                @DropRelic.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropRelic;
                @DropRelic.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropRelic;
                @ThrowRelic.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrowRelic;
                @ThrowRelic.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrowRelic;
                @ThrowRelic.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrowRelic;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @ResetRelic.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResetRelic;
                @ResetRelic.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResetRelic;
                @ResetRelic.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResetRelic;
                @CastPrimarySpell.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastPrimarySpell;
                @CastPrimarySpell.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastPrimarySpell;
                @CastPrimarySpell.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastPrimarySpell;
                @CastSecondarySpell.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSecondarySpell;
                @CastSecondarySpell.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSecondarySpell;
                @CastSecondarySpell.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSecondarySpell;
                @OpenConsole.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenConsole;
                @OpenConsole.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenConsole;
                @OpenConsole.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenConsole;
                @SubmitInput.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSubmitInput;
                @SubmitInput.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSubmitInput;
                @SubmitInput.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSubmitInput;
                @LastCommand.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLastCommand;
                @LastCommand.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLastCommand;
                @LastCommand.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLastCommand;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @LookAround.started += instance.OnLookAround;
                @LookAround.performed += instance.OnLookAround;
                @LookAround.canceled += instance.OnLookAround;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @DropRelic.started += instance.OnDropRelic;
                @DropRelic.performed += instance.OnDropRelic;
                @DropRelic.canceled += instance.OnDropRelic;
                @ThrowRelic.started += instance.OnThrowRelic;
                @ThrowRelic.performed += instance.OnThrowRelic;
                @ThrowRelic.canceled += instance.OnThrowRelic;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ResetRelic.started += instance.OnResetRelic;
                @ResetRelic.performed += instance.OnResetRelic;
                @ResetRelic.canceled += instance.OnResetRelic;
                @CastPrimarySpell.started += instance.OnCastPrimarySpell;
                @CastPrimarySpell.performed += instance.OnCastPrimarySpell;
                @CastPrimarySpell.canceled += instance.OnCastPrimarySpell;
                @CastSecondarySpell.started += instance.OnCastSecondarySpell;
                @CastSecondarySpell.performed += instance.OnCastSecondarySpell;
                @CastSecondarySpell.canceled += instance.OnCastSecondarySpell;
                @OpenConsole.started += instance.OnOpenConsole;
                @OpenConsole.performed += instance.OnOpenConsole;
                @OpenConsole.canceled += instance.OnOpenConsole;
                @SubmitInput.started += instance.OnSubmitInput;
                @SubmitInput.performed += instance.OnSubmitInput;
                @SubmitInput.canceled += instance.OnSubmitInput;
                @LastCommand.started += instance.OnLastCommand;
                @LastCommand.performed += instance.OnLastCommand;
                @LastCommand.canceled += instance.OnLastCommand;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI Navigation
    private readonly InputActionMap m_UINavigation;
    private IUINavigationActions m_UINavigationActionsCallbackInterface;
    private readonly InputAction m_UINavigation_MoveCursor;
    private readonly InputAction m_UINavigation_Confirm;
    private readonly InputAction m_UINavigation_StartGame;
    private readonly InputAction m_UINavigation_CancelSelection;
    public struct UINavigationActions
    {
        private @InputAsset m_Wrapper;
        public UINavigationActions(@InputAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveCursor => m_Wrapper.m_UINavigation_MoveCursor;
        public InputAction @Confirm => m_Wrapper.m_UINavigation_Confirm;
        public InputAction @StartGame => m_Wrapper.m_UINavigation_StartGame;
        public InputAction @CancelSelection => m_Wrapper.m_UINavigation_CancelSelection;
        public InputActionMap Get() { return m_Wrapper.m_UINavigation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UINavigationActions set) { return set.Get(); }
        public void SetCallbacks(IUINavigationActions instance)
        {
            if (m_Wrapper.m_UINavigationActionsCallbackInterface != null)
            {
                @MoveCursor.started -= m_Wrapper.m_UINavigationActionsCallbackInterface.OnMoveCursor;
                @MoveCursor.performed -= m_Wrapper.m_UINavigationActionsCallbackInterface.OnMoveCursor;
                @MoveCursor.canceled -= m_Wrapper.m_UINavigationActionsCallbackInterface.OnMoveCursor;
                @Confirm.started -= m_Wrapper.m_UINavigationActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_UINavigationActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_UINavigationActionsCallbackInterface.OnConfirm;
                @StartGame.started -= m_Wrapper.m_UINavigationActionsCallbackInterface.OnStartGame;
                @StartGame.performed -= m_Wrapper.m_UINavigationActionsCallbackInterface.OnStartGame;
                @StartGame.canceled -= m_Wrapper.m_UINavigationActionsCallbackInterface.OnStartGame;
                @CancelSelection.started -= m_Wrapper.m_UINavigationActionsCallbackInterface.OnCancelSelection;
                @CancelSelection.performed -= m_Wrapper.m_UINavigationActionsCallbackInterface.OnCancelSelection;
                @CancelSelection.canceled -= m_Wrapper.m_UINavigationActionsCallbackInterface.OnCancelSelection;
            }
            m_Wrapper.m_UINavigationActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveCursor.started += instance.OnMoveCursor;
                @MoveCursor.performed += instance.OnMoveCursor;
                @MoveCursor.canceled += instance.OnMoveCursor;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @StartGame.started += instance.OnStartGame;
                @StartGame.performed += instance.OnStartGame;
                @StartGame.canceled += instance.OnStartGame;
                @CancelSelection.started += instance.OnCancelSelection;
                @CancelSelection.performed += instance.OnCancelSelection;
                @CancelSelection.canceled += instance.OnCancelSelection;
            }
        }
    }
    public UINavigationActions @UINavigation => new UINavigationActions(this);

    // Sandstorm Sample Scene
    private readonly InputActionMap m_SandstormSampleScene;
    private ISandstormSampleSceneActions m_SandstormSampleSceneActionsCallbackInterface;
    private readonly InputAction m_SandstormSampleScene_CastSpell;
    public struct SandstormSampleSceneActions
    {
        private @InputAsset m_Wrapper;
        public SandstormSampleSceneActions(@InputAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @CastSpell => m_Wrapper.m_SandstormSampleScene_CastSpell;
        public InputActionMap Get() { return m_Wrapper.m_SandstormSampleScene; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SandstormSampleSceneActions set) { return set.Get(); }
        public void SetCallbacks(ISandstormSampleSceneActions instance)
        {
            if (m_Wrapper.m_SandstormSampleSceneActionsCallbackInterface != null)
            {
                @CastSpell.started -= m_Wrapper.m_SandstormSampleSceneActionsCallbackInterface.OnCastSpell;
                @CastSpell.performed -= m_Wrapper.m_SandstormSampleSceneActionsCallbackInterface.OnCastSpell;
                @CastSpell.canceled -= m_Wrapper.m_SandstormSampleSceneActionsCallbackInterface.OnCastSpell;
            }
            m_Wrapper.m_SandstormSampleSceneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CastSpell.started += instance.OnCastSpell;
                @CastSpell.performed += instance.OnCastSpell;
                @CastSpell.canceled += instance.OnCastSpell;
            }
        }
    }
    public SandstormSampleSceneActions @SandstormSampleScene => new SandstormSampleSceneActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLookAround(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnDropRelic(InputAction.CallbackContext context);
        void OnThrowRelic(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnResetRelic(InputAction.CallbackContext context);
        void OnCastPrimarySpell(InputAction.CallbackContext context);
        void OnCastSecondarySpell(InputAction.CallbackContext context);
        void OnOpenConsole(InputAction.CallbackContext context);
        void OnSubmitInput(InputAction.CallbackContext context);
        void OnLastCommand(InputAction.CallbackContext context);
    }
    public interface IUINavigationActions
    {
        void OnMoveCursor(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnStartGame(InputAction.CallbackContext context);
        void OnCancelSelection(InputAction.CallbackContext context);
    }
    public interface ISandstormSampleSceneActions
    {
        void OnCastSpell(InputAction.CallbackContext context);
    }
}
