using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Model;
using Moq;
using Xunit;

namespace BusinessLogic.Test
{
    public class FlowProviderTest
    {
        [Fact]
        public async Task Execute_RunWithFileNotFoundExceptionShould()
        {
            Mock<IFileProcessor> fileProcessor = new Mock<IFileProcessor>();
            Mock<IMediator> mediator = new Mock<IMediator>();
            Mock<IFileLocationProvider> locationProvider = new Mock<IFileLocationProvider>();
            IList<SourceLocations> locations = new List<SourceLocations>() {new SourceLocations(){Id = "id", LocationOnDisk = "somelocation"}};
            locationProvider.Setup(x => x.GetLocation()).Returns(Task.FromResult(locations));
            FlowProvider flowProvider = new FlowProvider(fileProcessor.Object, mediator.Object);
            await Assert.ThrowsAsync<FileNotFoundException>(async () => await flowProvider.Execute(locationProvider.Object));
        }
    }
}
