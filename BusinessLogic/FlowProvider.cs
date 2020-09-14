using System;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessLogic.SumNumber;
using MediatR;
using Model;

namespace BusinessLogic
{
    public class FlowProvider : IFlowProvider
    {
        private IFileProcessor _fileProcessor;
        private readonly IMediator _mediator;

        public FlowProvider(IFileProcessor fileProcessor, IMediator mediator)
        {
            _fileProcessor = fileProcessor;
            _mediator = mediator;

        }

        public async Task Execute(IFileLocationProvider locationProvider)
        {
           var locations = await locationProvider.GetLocation();
           foreach (var sourceLocation in locations)
           {
               var files = await _fileProcessor.GetFilesListFromLocation(sourceLocation.LocationOnDisk);
               foreach (var file in files)
               {
                    var content = await _fileProcessor.GetFileContent(file);
                    var contentObject = JsonSerializer.Deserialize<FileContent>(content);
                    await _mediator.Send(new SumNumberCommand(contentObject, Console.WriteLine));

               }
           }
        }
    }
}
