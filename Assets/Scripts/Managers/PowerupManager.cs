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
    private int powerupDuration;
    [SerializeField]
    private float powerupedSpeedMult = 3f;
    [SerializeField]
    private GameObject shieldPrefab;

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
                playerComponent.speedMult = powerupedSpeedMult;
                yield return new WaitForSeconds(powerupDuration);
                playerComponent.speedMult = 1f;
            }
            else if (powerup == PowerupEnum.shield && !playerComponent.sheildActivated)
            {
                var shield = player.transform.GetChild(0).gameObject;
                playerComponent.sheildActivated = true;
                shield.SetActive(true);
                yield return new WaitForSeconds(powerupDuration * 5);
                playerComponent.sheildActivated = false;
                shield.SetActive(false);
            }
        }
    }
}
