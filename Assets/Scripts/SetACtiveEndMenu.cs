using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetACtiveEndMenu : MonoBehaviour
{
    private void OnEnable()
    {
        EndGameMenu.instance.EndMenuAgain();
    }
}
