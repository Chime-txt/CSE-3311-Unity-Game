using UnityEngine;

public class leverScript : MonoBehaviour
{
    public bool canCreatePlatforms;
    public bool canDestroyPlatforms;
    public bool isLeverActive = false;

    public GameObject terrainGameObject;
    public Transform terrainLocation;

    public Sprite offLever, onLever;
    private SpriteRenderer spriteRenderer;
    private GameObject currentTerrain;
    private bool terrainExists = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = offLever;
        if (canCreatePlatforms && canDestroyPlatforms)
        {
            Debug.LogError("ERROR: CAN ONLY HAVE ONE BOOL CHECKED OFF");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Red") || other.gameObject.tag.Equals("Blue"))
        {

            ToggleLever();

        }
    }

    private void ToggleLever()
    {
        isLeverActive = !isLeverActive;
        if (isLeverActive)
        {
            spriteRenderer.sprite = onLever;
            if (canMovePlatforms = !terrainExists)
            {
                currentTerrain = Instantiate(terrainGameObject, terrainLocation.position, Quaternion.identity);
                terrainExists = true;
            }
            else if (canDestroyPlatforms = !terrainExists)
            {
                Destroy(currentTerrain);
            }
        }
        else
        {
            spriteRenderer.sprite = offLever;
            if (canMovePlatforms && terrainExists)
            {
                Destroy(currentTerrain);
                terrainExists = false ;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
