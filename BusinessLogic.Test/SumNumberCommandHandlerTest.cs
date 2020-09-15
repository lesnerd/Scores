using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogic.SumNumber;
using MediatR;
using Model;
using Moq;
using Xunit;

namespace BusinessLogic.Test
{
    public class SumNumberCommandHandlerTest
    {
        [Fact]
        public Task HandleShould()
        {
            Mock<SumNumberCommandHandler> sumNumberCommandHandler = new Mock<SumNumberCommandHandler>();
            FileContent fileContent = new FileContent() {score = new List<int>(){1, 2, 3, 4, 5}};
            SumNumberCommand sumNumberCommand = new SumNumberCommand(fileContent, s => { });
            sumNumberCommandHandler.Object.Handle(sumNumberCommand, new CancellationToken());
            return Task.CompletedTask;
        }
    }
}
