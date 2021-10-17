using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerationBehavior : MonoBehaviour
{
    //gets the blocks in the game
    public GameObject Square;
    public GameObject Iron;
    public GameObject Coal;

    //sets the spawn of blocks in the List
    private Vector3 _TerrainTrasform;
    private float _X = -10, _Y = 2f;

    private float _XRange = 0, _YRange = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Makes the Terrain ingame
        for (float x = 0; x < 80; x++)
        {
            for(float y = 0; y<1000; y++)
            {
                _Y--;
                _TerrainTrasform = new Vector3(_X, _Y);
                int rand = Random.Range(1, 100);
                if (rand <= 3 && y > 3)
                {
                    Instantiate(Iron, _TerrainTrasform, transform.rotation);
                }
                else if (rand > 3 && rand <= 6 && y > 5 && y < 100)
                {
                    Instantiate(Coal, _TerrainTrasform, transform.rotation);
                }
                else
                {
                    Instantiate(Square, _TerrainTrasform, transform.rotation);
                }

            }
            _X++;
            _Y = 2f;
        }
    }
}
