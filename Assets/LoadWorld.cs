using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWorld : MonoBehaviour
{

    // Model to use for stars...color will be replaced with one of the provided selections.
    public GameObject starPrefab = null;

    // Total number of stars in the game.
    public int starCount = 5 * 16;

    public float areaRadius = 20.0f;

    public float areaThickness = 5.0f;

    // Curiously there is no orange in the stock colors. I've faked it here to get my last star color.
    private Color[] colors = { Color.blue, Color.green, Color.yellow, Color.yellow, Color.red, Color.red, new Color(1.0f, 0.5f, 0.0f)};

    // Start is called before the first frame update
    void Start()
    {
        if (starPrefab != null)
        {
            for (int thisStar = 0; thisStar < starCount; thisStar++)
            {
                Color starColor = colors[Random.Range(0, colors.Length)];
                var where = Random.insideUnitCircle * (areaRadius * 2);
                var height = Random.Range(areaThickness / 2.0f, -(areaThickness / 2.0f));

                var what = Instantiate(starPrefab);
                what.transform.Translate(new Vector3(where.x, height, where.y));
                what.GetComponent<Renderer>().material.color = starColor;                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/**
 * We support four players, one of each color. This tag identifies each player.6
 * 
 */
enum PlayerIdentity
{ 
    RedPlayer, GreenPlayer, BluePlayer, YellowPlayer
}

public class StarSystem
{
    string name = null;

    // The interesting worlds in the sytem
    private List<World> worlds = null;

    // Need variables to track ships in this system
    private List<Fleet> localShips; 
}

public class Fleet
{
    PlayerIdentity owner;

    string fleetName;

    // Need variables to track ships in this system
    int scouts = 0;
    int patrol = 0;
    int assault = 0;
    int capital = 0;
    int colony = 0;
}

public class World
{
    // The production multiplier for this world. Resource rich worlds have a higher production multiplier.
    private float productionMultiplier = 1.0f;

    // Population growth multiplier. This can be zero (could be less than zero on particularly hostile planets).
    private float populationMultilpier = 1.0f / 5.0f;

    // If true then this planet can only be settled with domed city capability.
    private bool requiresDomedCities = false;

    // Identity of the owner of this system or null if the systrem is unowned.
    private PlayerIdentity? systemOwner = null;


    // System defenses for this planet.
    int defenseBoats = 0;
    int monitors = 0;

    // Local resources.
    int population = 0;
    int factories = 0;
}
