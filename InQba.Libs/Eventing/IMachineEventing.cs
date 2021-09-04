using System;

namespace InQba.Libs
{
    public interface IMachineEventing
    {
        event EventHandler Warning;
        event EventHandler NoStock;
        void OnWarningHappened(CustomEventArgs e);
        void OnStockIsLess(CustomEventArgs e);

    }
}