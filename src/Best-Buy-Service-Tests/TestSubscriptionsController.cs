
using AutoMapper;
using Best.Buy.Service.Implementation;
using Best.Buy.Repository;
using Microsoft.Extensions.Logging;
using Moq;

namespace Best.Buy.Service.Tests
{
    [TestClass]
    public class TestSubscriptionsController
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        //public SubscriptionsTest(ILogger<SubscriptionService> logger,
        //    IMapper mapper, UnitOfWork unitOfWork)
        //{
        //    this._unitOfWork = unitOfWork;
        //    this._logger = logger;
        //    this._mapper = mapper;
        //}

        [TestMethod]
        public async Task GetSubscriptions_ShouldReturnSameSubscriptionAsync()
        {
            //var controller = new SubscriptionController();
            //var unitWork = new Mock<UnitOfWork>();

            //var subscriptionService = new SubscriptionService(new UnitOfWork(), _mapper, _logger);
            //var result = await subscriptionService.GetSubscriptionsAsync(null);

            //Assert.Equals(3, result.Count());
        }
    }
}