using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSelection : MonoBehaviour
{
    
    public void Start()
    {
        gameObject.SetActive(false);
        
    }

    public void PurgeChildButtons(Component component)
    {
        // TODO modifier pour que ce soit que les childs buttons de l'instance actuelle jsp comment on fait :D
        foreach (Button btn in component.GetComponentsInChildren<Button>())
        {
            Destroy(btn.gameObject);
        }
    }



    public void CancelPopup()
    {
       
        gameObject.SetActive(false);

    }
}
