using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Model;

namespace BusinessLogic.SumNumber
{
    public class SumNumberCommand : IRequest
    {
        public SumNumberCommand(FileContent contentObject, Action<string> action)
        {
            Message = contentObject;
            Action = action;
        }

        public FileContent Message { get; }
        public Action<string> Action { get; }

    }
}
