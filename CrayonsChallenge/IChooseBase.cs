namespace CrayonsChallenge
{
    public interface IChooseBase
    {
        ShowMenu WhatMenu { get; }

        int ActivateOption(string activeChild);
        void ControlInfo();
        void EnterKeyAction();
        void InitializationMetod();
        void ShowActiveChild(string activeChild);
    }
}