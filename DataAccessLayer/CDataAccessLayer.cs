using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;

namespace DataAccessLayer
{
    public class CDataAccessLayer : IFileLocationProvider
    {
        private readonly ILogger _logger;
        private readonly VaronisTestContext _varonisTestContext;

        public CDataAccessLayer(ILogger<CDataAccessLayer> logger, VaronisTestContext context)
        {
            _logger = logger;
            _varonisTestContext = context;
        }

        public async Task<IList<Model.SourceLocations>> GetLocation()
        {
            var dbList = await _varonisTestContext.SourceLocations.ToListAsync();
            IList<Model.SourceLocations> modelList = new List<Model.SourceLocations>();
            
            //This could be clone or even in another class (with mapper). 
            foreach (var sourceLocations in dbList)
            {
                var model = new Model.SourceLocations();
                model.Id = sourceLocations.Id;
                model.LocationOnDisk = sourceLocations.LocationOnDisk;
                modelList.Add(model);
            }
            return modelList;
        }
    }
}
