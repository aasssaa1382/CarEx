
using CarWeb.Services.Option;
using System.Net.Http;
using static CarWeb.Components.Pages.Counter;

namespace CarWeb.Components.Pages
{
    public partial class Counter
    {

        private ApiResponse? drivers;
        private HttpClient client=new();
        protected override async Task OnInitializedAsync()
        {
            drivers = await LoadPage(1);
        }


        private async Task<ApiResponse> LoadPage(int pageIndex)
        {
            drivers= await client.GetFromJsonAsync<ApiResponse>($"{APIs.BaseUrl}{APIs.GetDrives}{pageIndex}&PageSize=5") ?? new();
            StateHasChanged(); 
            return drivers;
        }

        public class ApiResponse
        {
            public bool Result { get; set; }
            public string? ErrorMessages { get; set; }
            public string? ErrorMessagesIX { get; set; }
            public Content? Content { get; set; }
        }

        public class Content
        {
            public int PageIndex { get; set; }
            public int PageSize { get; set; }
            public bool HasNext { get; set; }
            public bool HasPrevious { get; set; }
            public int TotalPages { get; set; }
            public int TotalRecord { get; set; }
            public List<Driver>? Data { get; set; }
        }

        public class Driver
        {
            public int DriverId { get; set; }
            public string? NameFamily { get; set; }
            public string? Expertise { get; set; }
            public string? ImageProFile { get; set; }
            public bool IsActive { get; set; }
            public int ProvinceId { get; set; }
            public int SeenCount { get; set; }
            public string? CarriagePermit { get; set; }
            public int Priority { get; set; }
            public int Rank { get; set; }
            public int Score { get; set; }
            public string? CarTypeId { get; set; }
        }







    }
}
