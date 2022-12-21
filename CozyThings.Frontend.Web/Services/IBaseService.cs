using CozyThings.Frontend.Web.Models;

namespace CozyThings.Frontend.Web.Services
{
    public interface IBaseService : IDisposable
    {
        public ResponseDto responseDto { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
