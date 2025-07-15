using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RayCaster
{

    PointerEventData pointerData;
    List<RaycastResult> results = new List<RaycastResult>();

    //�R���X�g���N�^
    public RayCaster(EventSystem eventSystem)
    {
        pointerData = new PointerEventData(eventSystem);
    }

    //�ړI��rayCaster������
    public List<RaycastResult> RayCastResults(GraphicRaycaster raycaster)
    {
        results.Clear();
        pointerData.position = Input.mousePosition;
        raycaster.Raycast(pointerData, results);
        return results;
    }
}
