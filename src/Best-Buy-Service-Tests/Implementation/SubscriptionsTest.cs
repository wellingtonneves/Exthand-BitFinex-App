using Microsoft.VisualStudio.TestTools.UnitTesting;
using Best.Buy.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Best.Buy.Repository;
using AutoMapper;

namespace Best.Buy.Service.Tests
{
    [TestClass()]
    public class SubscriptionsTest
    {
        private readonly ILogger<ProductService> logger;
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper mapper;


        [TestMethod()]
        public async void GetSubscriptionsTest()
        {
        
            //var subscriptionService = new SubscriptionService(unitOfWork, mapper, logger);

            //var result = await subscriptionService.GetSubscriptionsAsync(null);

            //Assert.Equals(3, result.Count());
        }

    }
}