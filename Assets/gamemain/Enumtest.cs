using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumtest : MonoBehaviour
{
    public enum elementType { 火,水,風,土};
    public elementType myelementType;  //1.火 2.水 3.風 4.土
    void Start()
    {
        switch (myelementType)
        {
            case elementType.火:
                print("火屬性");
                break;
            case elementType.水:
                print("水屬性");
                break;
            case elementType.風:
                print("風屬性");
                break;
            case elementType.土:
                print("土屬性");
                break;

        }
    }

    
}
