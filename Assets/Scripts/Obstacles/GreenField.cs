using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenField : MonoBehaviour
{
    private enum Boosters { Plus10, Plus15, Plus30, Plus40, x2, x3 }
    private string[] _boosterNames = new string[] { "+10", "+15", "+30", "+40", "x2", "x3" };

    private Boosters _leftBooster;
    private Boosters _rightBooster;
    [SerializeField] private Text _leftBoostText;
    [SerializeField] private Text _rightBoostText;
    [SerializeField] private GameObject _leftBoosterField;
    [SerializeField] private GameObject _rightBoosterField;   


    private void Start()
    {
        GenerateBoosts();
    }

    private void GenerateBoosts() 
    {
        var randomValLeft = Random.Range(0, 6);
        var randomValRight = Random.Range(0, 6);
        _leftBooster = (Boosters)randomValLeft;
        _rightBooster = (Boosters)randomValRight;      

        PrepareBoosters();
    }

    private void PrepareBoosters() 
    {
        _leftBoostText.text = _boosterNames[(int)_leftBooster];
        _rightBoostText.text = _boosterNames[(int)_rightBooster];

        _leftBoosterField.tag = _leftBooster.ToString();
        _rightBoosterField.tag = _rightBooster.ToString();
    }

    public void DestroyBoosters() 
    {
        if (_leftBoosterField)
        {
            Destroy(_leftBoostText);
            Destroy(_leftBoosterField);
        }
        if (_rightBoosterField)
        {
            Destroy(_rightBoostText);
            Destroy(_rightBoosterField);
        }

    }
}
