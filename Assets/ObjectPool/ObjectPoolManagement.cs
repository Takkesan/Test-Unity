using UnityEngine;

public class ObjectPoolManagement : MonoBehaviour
{
    [SerializeField] GameObject objectToPool;
    [Range(5,100)] [SerializeField] int poolSize = 5;

    delegate void ObjectDisabler(GameObject obj);
    void Start()
    {
        ObjectDisabler objectDisabler = (obj) => obj.SetActive(false);
        
        //poolSize分のオブジェクトを貯めておく
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = addNewObject();
            obj.SetActive(false);
        }
    }

    public GameObject ReturnActiveGameObject()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            //もし、オブジェクトがアクティブであれば、そのオブジェクトを返す
            if(obj.gameObject.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        return addNewObject();
    }
    
    private GameObject addNewObject()
    {
        GameObject obj = Instantiate(objectToPool);
        obj.transform.parent = transform;
        return obj;
    }
}
