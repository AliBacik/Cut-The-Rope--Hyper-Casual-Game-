using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Top _Top;

    [SerializeField] private GameObject[] IP_Merkezleri;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);

            if (hit.collider != null) {

                if (hit.collider.CompareTag("Merkez_1"))
                {
                    hit.collider.gameObject.SetActive(false);

                    // _Top.HingeControl["Merkez_1"].enabled = false;

                    foreach (var item in IP_Merkezleri)
                    {
                        if (item.GetComponent<Ip_Yonetimi>().HingeAdi == "Merkez_1")
                        {
                            foreach (var item2 in item.GetComponent<Ip_Yonetimi>().BaglantiHavuzu)
                            {
                                item2.SetActive(false);
                            }
                        }
                    }
                }

                else if (hit.collider.CompareTag("Merkez_2"))
                {
                    hit.collider.gameObject.SetActive(false);
                    //_Top.HingeControl["Merkez_2"].enabled = false;

                    foreach (var item in IP_Merkezleri)
                    {
                        if (item.GetComponent<Ip_Yonetimi>().HingeAdi == "Merkez_2")
                        {
                            foreach (var item2 in item.GetComponent<Ip_Yonetimi>().BaglantiHavuzu)
                            {
                                item2.SetActive(false);
                            }
                        }
                    }
                }




            }


            
        }
    }
}
