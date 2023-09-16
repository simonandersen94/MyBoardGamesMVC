namespace MyBoardGamesMVC.Access.Interfaces {
    public interface IServiceConnection {
        public string? BaseUrl { get; set; }
        public string? UseUrl { get; set; }

        public HttpClient HttpEnabler { get; init; }
        Task<HttpResponseMessage?> CallServiceGet();
    }
}
