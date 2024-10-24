using Microsoft.AspNetCore.Mvc;
using StellantisSupportAPI.MLModels;

namespace StellantisSupportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly ProductRecommender _productRecommender;

        public RecommendationController(ProductRecommender productRecommender)
        {
            _productRecommender = productRecommender;
        }

        [HttpPost("train")]
        public IActionResult TrainModel([FromBody] string dataPath)
        {
            _productRecommender.TrainModel(dataPath);
            return Ok("Modelo treinado com sucesso!");
        }

        [HttpGet("predict")]
        public IActionResult Predict(int userId, int productId)
        {
            var score = _productRecommender.Predict(userId, productId);
            return Ok(new { Score = score });
        }
    }
}
