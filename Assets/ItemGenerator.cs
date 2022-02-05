using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;

    public GameObject coinPrefab;

    public GameObject conePrefab;

    private GameObject unitychan;


    private int startPos = 80;

    private int goalPos = 360;

    private float posRange = 3.4f;

    // 前もってターゲットを生成しておく距離
    private float previousDistance = 60.0f;

    // 連続で生成しない
    private bool oneTime = true;

    // 生成した場所を保管
    private float oneTimePosZ;

    void Start()
    {
        /*
        for (int i = startPos; i < goalPos; i += 15)
        {
            int num = Random.Range(1, 11);

            if (num <= 2)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                for(int j = -1; j <= 1; j++)
                {
                    int item = Random.Range(1, 11);

                    int offsetZ = Random.Range(-5, 6);

                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
        */

        this.unitychan = GameObject.Find("unitychan");
    }

    void Update()
    {
        if (startPos - this.previousDistance < unitychan.transform.position.z && unitychan.transform.position.z < goalPos - this.previousDistance)
        {
            if (oneTime)
            {
                if ((unitychan.transform.position.z - (startPos - this.previousDistance)) % 15.0f <= 0.5f)
                {
                    this.oneTime = false;

                    this.oneTimePosZ = unitychan.transform.position.z;

                    int num = Random.Range(1, 11);

                    if (num <= 2)
                    {
                        for (float j = -1; j <= 1; j += 0.4f)
                        {
                            GameObject cone = Instantiate(conePrefab);
                            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + this.previousDistance);
                        }
                    }
                    else
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int item = Random.Range(1, 11);

                            int offsetZ = Random.Range(-5, 6);

                            if (1 <= item && item <= 6)
                            {
                                GameObject coin = Instantiate(coinPrefab);
                                coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.unitychan.transform.position.z + this.previousDistance + offsetZ);
                            }
                            else if (7 <= item && item <= 9)
                            {
                                GameObject car = Instantiate(carPrefab);
                                car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.unitychan.transform.position.z + this.previousDistance + offsetZ);
                            }
                        }
                    }
                }
            }
            else
            {
                if (unitychan.transform.position.z - this.oneTimePosZ > 1.0f)
                {
                    oneTime = true;
                }
            }
        }
    }
}
