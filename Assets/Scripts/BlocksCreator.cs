using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksCreator : MonoBehaviour
{
    [SerializeField] private float maxTime = 1;
    private float timer = 0;
    [SerializeField] GameObject blocks;
    [SerializeField] private float height;
    [SerializeField] private GameState state;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject newblocks = Instantiate(blocks);
        //newblocks.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(state.isStart)
        {
            if (timer > maxTime)
            {
                GameObject newblocks = Instantiate(blocks);
                newblocks.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }
}
