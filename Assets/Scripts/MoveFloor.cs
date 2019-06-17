using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public GameObject floor1;
    public GameObject floor2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(floor1.transform.position.x < floor2.transform.position.x && !CanSee(floor1))
        {
            floor1.transform.position = new Vector3(floor1.transform.position.x + 64 * 2, floor1.transform.position.y, floor1.transform.position.z);
        }
        if (floor2.transform.position.x < floor1.transform.position.x && !CanSee(floor2))
        {
            floor2.transform.position = new Vector3(floor2.transform.position.x + 64 * 2, floor2.transform.position.y, floor2.transform.position.z);
        }
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
