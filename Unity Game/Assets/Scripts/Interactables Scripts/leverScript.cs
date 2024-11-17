using UnityEngine;

public class leverScript : MonoBehaviour
{
    [SerializeField] bool canCreatePlatforms;
	[SerializeField] bool canDestroyPlatforms;
	[SerializeField] bool isLeverActive = false;

	[SerializeField] GameObject terrainGameObject;
	[SerializeField] Transform terrainLocation;

	[SerializeField] Sprite offLever, onLever;
    private SpriteRenderer spriteRenderer;
    private GameObject currentTerrain;
    private bool terrainExists;

    // Start is called before the first frame update
    void Start()
    {
        terrainExists = false;
		spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = offLever;
        if (canCreatePlatforms && canDestroyPlatforms)
        {
            Debug.LogError("ERROR: CAN ONLY HAVE ONE BOOL CHECKED OFF");
        }
    }

    // After an object collides with the lever, check if the collision is
    // a player before calling another function to toggle the lever
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Red") || other.gameObject.tag.Equals("Blue"))
        {
            ToggleLever();
        }
    }

    // After the player collides with the lever, either spawn or delete the terrain
    private void ToggleLever()
    {
        isLeverActive = !isLeverActive;

        if (isLeverActive)
        {
            spriteRenderer.sprite = onLever;

            if (canCreatePlatforms && !terrainExists) // Use '&&' and '=='
            {
                currentTerrain = Instantiate(terrainGameObject, terrainLocation.position, Quaternion.identity);
                terrainExists = true;
            }
            else if (canDestroyPlatforms && terrainExists) // Use '&&' and '=='
            {
                Destroy(currentTerrain);
                terrainExists = false;
            }
        }
        else
        {
            spriteRenderer.sprite = offLever;

            if (canCreatePlatforms && terrainExists)
            {
                Destroy(currentTerrain);
                terrainExists = false;
            }
        }
    }

}