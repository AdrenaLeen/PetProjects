﻿namespace CarEventsWithLambdas
{
    class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message) => msg = message;
    }
}
