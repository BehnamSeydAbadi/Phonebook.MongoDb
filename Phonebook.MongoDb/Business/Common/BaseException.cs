﻿namespace Business.Common
{
    public abstract class BaseException : Exception
    {
        public BaseException(string message) : base(message)
        {

        }
    }
}
