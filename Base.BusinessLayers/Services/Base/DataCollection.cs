namespace Base.BusinessLayers.Services.Base
{
    internal class DataCollection<TModel> where TModel : class, new()
    {
        public List<TModel> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
    }
}