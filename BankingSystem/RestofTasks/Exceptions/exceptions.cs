using System;
namespace RestofTasks.Exceptions
{
   
        
        public class InsufficientFundException : Exception
        {
            public InsufficientFundException(string message) : base(message) { }
        }

       
        public class InvalidAccountException : Exception
        {
            public InvalidAccountException(string message) : base(message) { }
        }

       
        public class OverDraftLimitExceededException : Exception
        {
            public OverDraftLimitExceededException(string message) : base(message) { }
        }
    }



