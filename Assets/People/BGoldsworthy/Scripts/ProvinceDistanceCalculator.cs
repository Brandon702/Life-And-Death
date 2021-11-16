using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinceDistanceCalculator : MonoBehaviour
{
    Province province;

    private void Start()
    {
        province = transform.gameObject.GetComponent<Province>();
        //StartCoroutine(ExecuteDeletion(1));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent("Province") != null)
        {
            province.adjacentProvinces.Add(other.gameObject.GetComponent<Province>());
        }
    }
    IEnumerator ExecuteDeletion(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Coroutine Called");
        deleteBoxCollider();
    }
    private void deleteBoxCollider()
    {
        Debug.Log("Collider Deleted");
        BoxCollider box = province.gameObject.GetComponentInParent<BoxCollider>();
        box.isTrigger = false;
    }

}