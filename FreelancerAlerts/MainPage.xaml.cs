using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Web;
using System.Timers;
using System.Diagnostics;
using System.Collections.Generic;

namespace FreelancerAlerts
{
    //https://developers.freelancer.com/docs/use-cases/bidding-on-a-project
    public partial class MainPage : ContentPage
    {
        private static System.Timers.Timer RefreshTimer;
        public ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            Task.Run(async () => await GetAsync(new HttpClient())).Wait();

            SetTimer();
            RefreshTimer.Stop();
            RefreshTimer.Start();

        }

        private void SetTimer()
        {
            // Create a timer with a 60 sec interval.
            RefreshTimer = new System.Timers.Timer(10000);
            RefreshTimer.Elapsed += OnTimedEvent;
            RefreshTimer.AutoReset = true;
            RefreshTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                lblSts.Text = DateTime.Now.ToString();
            });
            
            Task.Run(async () => {
                    await GetAsync(new HttpClient());
                });
        }

        private async Task GetAsync(HttpClient httpClient)
        {
            string searchTag = HttpUtility.UrlEncode("iot esp32 electronics stm32 pcb firmware fpga");
            int searchLimit = 10;

            using HttpResponseMessage response = await httpClient.GetAsync("https://www.freelancer.com/api/projects/0.1/projects/active/?compact=&limit="+searchLimit+"&project_types=fixed&query="+ searchTag + "&full_description=true");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(jsonResponse);

            foreach (var project in rootObject.Result.Projects)
            {
                if (Projects.Any(x => x.Id == project.Id))
                {
                    //Debug.WriteLine("Project Exists");
                }
                else
                {
                    Projects.Add(project);
                }
            }

            httpClient.Dispose();
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            bidProjectID.Text=e.Parameter.ToString();
        }
    }

}
