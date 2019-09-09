using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The player to follow")]
    private Transform m_playerTranform;

    [SerializeField]
    [Tooltip("The offset from the Player's origin to the camera")]
    private Vector3 m_Offset;

    [SerializeField]
    [Tooltip("How quickly the player can rotate the camera to the left and the right")]
    private float m_RotationSpeed = 10;
    #endregion

    #region Main Updates
    private void LateUpdate()
    {
        Vector3 newPos = m_playerTranform.position + m_Offset;

        transform.position = Vector3.Slerp(transform.position, newPos, 1);

        float rotationAmount = m_RotationSpeed * Input.GetAxis("Mouse X");
        transform.RotateAround(m_playerTranform.position, Vector3.up, rotationAmount);

        m_Offset = transform.position - m_playerTranform.position;
    }
    #endregion
}
