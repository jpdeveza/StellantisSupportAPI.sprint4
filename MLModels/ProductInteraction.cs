namespace StellantisSupportAPI.MLModels
{
    public class ProductInteraction
    {
        public float UserId { get; set; }
        public float ProductId { get; set; }
        public float Label { get; set; } // Pode ser um valor indicando uma avaliação, compra, etc.
    }
}
