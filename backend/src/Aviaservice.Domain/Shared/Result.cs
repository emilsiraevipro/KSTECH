using System;
using System.Collections.Generic;
using System.Text;

namespace KSTECH.Domain.Shared
{
    public class Result
    {
        public Result(bool isSuccess, string error)
        {
            if(isSuccess && error is not null)
                throw new InvalidOperationException(error);
            if(!IsSuccess && error == null)
                throw new InvalidOperationException(error);
            IsSuccess = isSuccess;
            Error = error;
        }
        public string? Error { get; set; }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        public static Result Success() => new Result(true, null);
        public static Result Failure(string error) => new Result(false, error);
    }
}

namespace KSTECH.Domain.Shared
{
    public class Result<TValue> : Result
    {
        private readonly TValue _value;

        public Result(TValue value, bool isSuccess, string error) : base(isSuccess, error)
        {
            _value = value;
        }

        public TValue Value => IsSuccess 
            ? _value 
            : throw new InvalidOperationException("The value of a failure resilt can not be accessed.");
        public static Result<TValue> Success(TValue value)
        {
            return new Result<TValue>(value, true, null);
        }
        public static new Result<TValue> Failure(string error)
        {
            return new Result<TValue>(default!, false, error);
        }
        public static implicit operator Result<TValue>(TValue value) => new Result<TValue>(value, true, null);
        public static implicit operator Result<TValue>(string error) => new Result<TValue>(default!, true, error);
    }
}