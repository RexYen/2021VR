using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace UnityEngine.XR.Interaction.Toolkit
{
    /// <summary>
    /// A locomotion provider that allows the user to rotate their rig using a 2D axis input
    /// from an input system action.
    /// </summary>
    ///[AddComponentMenu("XR/Locomotion/Snap Turn Provider (Action-based)")]
    ///[HelpURL(XRHelpURLConstants.k_ActionBasedSnapTurnProvider)]
    public class Secondary : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The Input System Action that will be used to read Snap Turn data from the left hand controller. Must be a Value Vector2 Control.")]
        InputActionProperty m_LeftHandSecondaryAction;
        /// <summary>
        /// The Input System Action that will be used to read Snap Turn data sent from the left hand controller. Must be a <see cref="InputActionType.Value"/> <see cref="Vector2Control"/> Control.
        /// </summary>
        public InputActionProperty leftHandSecondaryAction
        {
            get => m_LeftHandSecondaryAction;
            set => SetInputActionProperty(ref m_LeftHandSecondaryAction, value);
        }
        /*
        [SerializeField]
        [Tooltip("The Input System Action that will be used to read Snap Turn data from the right hand controller. Must be a Value Vector2 Control.")]
        InputActionProperty m_RightHandSnapTurnAction;
        /// <summary>
        /// The Input System Action that will be used to read Snap Turn data sent from the right hand controller. Must be a <see cref="InputActionType.Value"/> <see cref="Vector2Control"/> Control.
        /// </summary>
        public InputActionProperty rightHandSnapTurnAction
        {
            get => m_RightHandSnapTurnAction;
            set => SetInputActionProperty(ref m_RightHandSnapTurnAction, value);
        }
        */
        /// <summary>
        /// See <see cref="MonoBehaviour"/>.
        /// </summary>
        protected void OnEnable()
        {
            m_LeftHandSecondaryAction.EnableDirectAction();
            //m_RightHandSnapTurnAction.EnableDirectAction();
        }

        /// <summary>
        /// See <see cref="MonoBehaviour"/>.
        /// </summary>
        protected void OnDisable()
        {
            m_LeftHandSecondaryAction.DisableDirectAction();
            //m_RightHandSnapTurnAction.DisableDirectAction();
        }

        /// <inheritdoc />
        public float ReadInput()
        {
            var leftHandValue = m_LeftHandSecondaryAction.action?.ReadValue<float>() ?? 0.0f;
            //var rightHandValue = m_RightHandSnapTurnAction.action?.ReadValue<Vector2>() ?? Vector2.zero;

            return leftHandValue;
        }

        void SetInputActionProperty(ref InputActionProperty property, InputActionProperty value)
        {
            if (Application.isPlaying)
                property.DisableDirectAction();

            property = value;

            if (Application.isPlaying && isActiveAndEnabled)
                property.EnableDirectAction();
        }
    }
}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secondary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/