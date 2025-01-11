using API.Interfaces;

namespace API.Services
{
    public class CampgroundService
    {
        private readonly ICampgroundRepository _campgroundRepository;
        private readonly IReviewRepository _reviewRepository;

        public CampgroundService(ICampgroundRepository campgroundRepository, IReviewRepository reviewRepository)
        {
            _campgroundRepository = campgroundRepository;
            _reviewRepository = reviewRepository;
        }

    }
}
