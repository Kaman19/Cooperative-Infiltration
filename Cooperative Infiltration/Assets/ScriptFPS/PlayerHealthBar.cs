using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{


    [Tooltip("Image component dispplaying current health")]
    public Image healthFillImage;

    Health m_PlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacterController playerCharacterController = GameObject.FindObjectOfType<PlayerCharacterController>();

        m_PlayerHealth = playerCharacterController.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        healthFillImage.fillAmount = m_PlayerHealth.currentHealth / m_PlayerHealth.maxHealth;
    }
}
