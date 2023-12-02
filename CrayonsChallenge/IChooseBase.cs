namespace CrayonsChallenge
{
    public interface IChooseBase
    {
        ShowMenu WhatMenu { get; }

        void EnterKeyAction();
        void InitializationMetod();
    }
}