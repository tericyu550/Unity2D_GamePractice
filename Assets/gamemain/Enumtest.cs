using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumtest : MonoBehaviour
{
    public enum elementType { ��,��,��,�g};
    public elementType myelementType;  //1.�� 2.�� 3.�� 4.�g
    void Start()
    {
        switch (myelementType)
        {
            case elementType.��:
                print("���ݩ�");
                break;
            case elementType.��:
                print("���ݩ�");
                break;
            case elementType.��:
                print("���ݩ�");
                break;
            case elementType.�g:
                print("�g�ݩ�");
                break;

        }
    }

    
}
