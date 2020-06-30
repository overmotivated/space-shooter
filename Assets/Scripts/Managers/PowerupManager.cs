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
                GameObject shield;
                if (playerComponent.sheildActivated)
                {
                    shield = player.transform.GetChild(0).gameObject;
                }
                else
                {
                    playerComponent.sheildActivated = true;
                    shield = Instantiate(shieldPrefab, player.transform.position, Quaternion.identity);
                    shield.transform.parent = player.transform;
                }
                yield return new WaitForSeconds(powerupDuration * 5);
                playerComponent.sheildActivated = false;
                Destroy(shield);
            }
        }
    }
}
