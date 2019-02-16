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
