using System;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using EstonianWeather.Data;

namespace EstonianWeather.Domain
{
    public class FinnishForecastService
    {
        private readonly DbConnection _db;

        public FinnishForecastService(ApplicationDbContext dbContext)
        {
            _db = dbContext.GetDbConnection();
        }
    }
}