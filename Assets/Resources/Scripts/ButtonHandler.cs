using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private FollowWP _followWP;
    [SerializeField] private Button _buttonRuin;
    [SerializeField] private Button _buttonHeli;
    [SerializeField] private Button _buttonFactory;
    [SerializeField] private Button _buttonOilField;

    private void Start()
    {
        _buttonRuin.onClick.AddListener(() => GoToDestination(7));
        _buttonHeli.onClick.AddListener(() => GoToDestination(0));
        _buttonFactory.onClick.AddListener(() => GoToDestination(2));
        _buttonOilField.onClick.AddListener(() => GoToDestination(5));
    }

    private void GoToDestination(int destinationIndex)
    {
        _followWP.GoToDestination(destinationIndex);
    }
}
