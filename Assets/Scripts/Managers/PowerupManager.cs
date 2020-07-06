using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum PowerupEnum { trippleShot, speed, shield };

public class PowerupManager : MonoBehaviour
{
    private GameObject player;
    private Fire fireComponent;
    private Player playerComponent;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private int powerupDuration;
    [SerializeField]
    private float powerupedSpeedMult = 2f;

    private void Start()
    {
        player = GameObject.Find("Player");
        fireComponent = player.GetComponent<Fire>();
        playerComponent = player.GetComponent<Player>();
    }

    public void UsePowerup(PowerupEnum powerup)
    {
        StartCoroutine(ActivatePowerup());
        IEnumerator ActivatePowerup()
        {
            if (powerup == PowerupEnum.trippleShot)
            {
                fireComponent.tripleShotAlowed = true;
                yield return new WaitForSeconds(powerupDuration);
                fireComponent.tripleShotAlowed = false;
            }
            else if (powerup == PowerupEnum.speed)
            {
                playerComponent.SpeedMult = powerupedSpeedMult;
                yield return new WaitForSeconds(powerupDuration);
                playerComponent.SpeedMult = 1f;
            }
            else if (powerup == PowerupEnum.shield && !playerComponent.SheildActivated)
            {
                playerComponent.SheildActivated = true;
                shield.SetActive(true);
                yield return new WaitForSeconds(powerupDuration * 3);
                playerComponent.SheildActivated = false;
                shield.SetActive(false);
            }
        }
    }
}
