using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public GameObject obs1;
    public GameObject obs2;
    public GameObject obs3;
    public GameObject obs4;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsBehind(obs1) && !CanSee(obs1))
        {
            obs1.transform.position = new Vector3(obs4.transform.position.x + 6, Random.Range(-1, 4), obs1.transform.position.z);
        }
        if (IsBehind(obs2) && !CanSee(obs2))
        {
            obs2.transform.position = new Vector3(obs1.transform.position.x + 6, Random.Range(-1, 4), obs2.transform.position.z);
        }
        if (IsBehind(obs3) && !CanSee(obs3))
        {
            obs3.transform.position = new Vector3(obs2.transform.position.x + 6, Random.Range(-1, 4), obs3.transform.position.z);
        }
        if (IsBehind(obs4) && !CanSee(obs4))
        {
            obs4.transform.position = new Vector3(obs3.transform.position.x + 6, Random.Range(-1, 4), obs4.transform.position.z);
        }
    }

    public bool IsBehind(GameObject gameObj)
    {
        if(gameObj.name == obs1.name)
        {
            return gameObj.transform.position.x < obs2.transform.position.x;
        }
        if (gameObj.name == obs2.name)
        {
            return gameObj.transform.position.x < obs3.transform.position.x;
        }
        if (gameObj.name == obs3.name)
        {
            return gameObj.transform.position.x < obs4.transform.position.x;
        }
        if (gameObj.name == obs4.name)
        {
            return gameObj.transform.position.x < obs1.transform.position.x;
        }

        return false;
    }

    private bool CanSee(GameObject gameObj)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(GetComponent<Camera>());
        if (GeometryUtility.TestPlanesAABB(planes, gameObj.GetComponent<Collider2D>().bounds))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
