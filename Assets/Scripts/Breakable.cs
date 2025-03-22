using UnityEngine;
using System.Collections.Generic;

public class Breakable : MonoBehaviour
{
    public List<GameObject> breakablePieces;

    void Start()
    {
        foreach (var piece in breakablePieces)
            piece.SetActive(false);
    }

    public void Break()
    {
        foreach (var piece in breakablePieces)
        {
            piece.SetActive(true);
            piece.transform.parent = null;
        }

        gameObject.SetActive(false);
    }
}
