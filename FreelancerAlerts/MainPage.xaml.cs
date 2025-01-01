using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Web;

namespace FreelancerAlerts
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Task.Run(async () => await GetAsync(new HttpClient())).Wait();
        }

        private async Task GetAsync(HttpClient httpClient)
        {
            string searchTag = HttpUtility.UrlEncode("iot esp32 electronics");
            int searchLimit = 10;

            using HttpResponseMessage response = await httpClient.GetAsync("https://www.freelancer.com/api/projects/0.1/projects/active/?compact=&limit="+searchLimit+"&project_types=fixed&query="+ searchTag + "&full_description=true");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(jsonResponse);

            foreach (var project in rootObject.Result.Projects)
            {
                Projects.Add(project);
                //Debug.WriteLine($"Project ID: {project.Id}, Title: {project.Title}, Status: {project.Status}");
            }
        }
    }

}
