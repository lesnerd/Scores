using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BusinessLogic.SumNumber
{
    public class SumNumberCommandHandler : IRequestHandler<SumNumberCommand, Unit>
    {
        public Task<Unit> Handle(SumNumberCommand request, CancellationToken cancellationToken)
        {
            int sum = 0;
            foreach (var score in request.Message.score)
            {
                sum += score;
            }
            var listToString = request.Message.score.Select(i => i.ToString(CultureInfo.InvariantCulture)).Aggregate((s1, s2) => s1 + ", " + s2);
            request.Action($"For the list: {listToString}, the sum is: {sum}");
            return Task.FromResult(new Unit());
        }
    }
}
