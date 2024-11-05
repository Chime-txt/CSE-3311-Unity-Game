using UnityEngine;

public class ammoGem : MonoBehaviour
{
    [Header("Variables for Red Slime")]
    public ammoBar redAmmoBar;
    public playerShoot redPlayerShoot;
    [Header("Variables for Blue Slime")]
    public ammoBar blueAmmoBar;
    public playerShoot bluePlayerShoot;

    // Collect gem and refill ammo bar based on the player's tag
    // Triggering this function requires the player to collect the white gem
    // instead of their respective color gem.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Red"))
        {
            if (redAmmoBar != null)
            {
                redAmmoBar.SetAmmo(5);
                redPlayerShoot.enabled = true;
                redPlayerShoot.AmmoCount = 5;
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Blue"))
        {
            if (blueAmmoBar != null)
            {
                blueAmmoBar.SetAmmo(5);
                bluePlayerShoot.enabled = true;
                bluePlayerShoot.AmmoCount = 5;
                Destroy(gameObject);
            }
        }
    }
}