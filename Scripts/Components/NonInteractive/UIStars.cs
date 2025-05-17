using System;
using System.Collections.Generic;
using UnityEngine;

public class UIStars : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _stars;

    private void Awake()
    {
        ClearStars();
    }

    private void OnDisable()
    {
        ClearStars();
    }

    public void SetData(int starsCount)
    {
        for (int i = 0; i < starsCount; i++)
        {
            _stars[i].SetActive(true);
        }
        gameObject.SetActive(true);
    }

    private void ClearStars()
    {
        _stars.ForEach(star => star.SetActive(false));
    }
}
