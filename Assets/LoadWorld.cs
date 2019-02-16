using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWorld : MonoBehaviour
{

    // Model to use for stars...color will be replaced with one of the provided selections.
    public GameObject starPrefab = null;

    // Total number of stars in the game.
    public int starCount = 8000; //5 * 16;

    private Color[] colors = { Color.blue, Color.green, Color.yellow, Color.red,  new Color(1.0f, 0.5f, 0.0f)};

    // Start is called before the first frame update
    void Start()
    {
        if (starPrefab != null)
        {
            for (int thisStar = 0; thisStar < starCount; thisStar++)
            {
                Color starColor = colors[Random.Range(0, 5)];
                var where = Random.insideUnitCircle * 100;
                var height = Random.Range(10.0f, -10.0f);

                var what = Instantiate(starPrefab);
                what.transform.Translate(new Vector3(where.x, where.y, height));
                what.GetComponent<Renderer>().material.color = starColor;                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
