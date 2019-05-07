using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JSON1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(@"http://pcbstuou.w27.wh-2.com/webservices/3033/api/Movies?number=100").Result;

                if(response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var movie = JsonConvert.DeserializeObject<List<Movies>>(content);

                    foreach(var m in movie)
                    {
                        if (m.num_voted_users >= 350000)
                        {
                            lstBoxUserVotes.Items.Add(m.movie_title);
                        }
                    }

                    int russoM = 0;

                    foreach(var m in movie)
                    {
                        if(m.director_name == "Anthony Russo")
                        {
                            russoM++;
                        }
                    }

                    lstBoxAnthony.Items.Add(russoM);

                    int robertD = 0;

                    foreach(var m in movie)
                    {
                        if(m.actor_1_name == "Robert Downey Jr.")
                        {
                            robertD++;
                        }

                    }

                    lstBoxRobert.Items.Add(robertD);

                    double score = 0.0;
                    string name = string.Empty;

                    foreach(var m in movie)
                    {
                        if(m.imdb_score > score)
                        {
                            score = m.imdb_score;
                            name = m.movie_title;
                        }
                    }

                    lstBoxHighestIMDB.Items.Add(name);

                    foreach (var m in movie)
                    {
                        var gs = m.genres.Split('|');

                        foreach (var g in gs)
                        {
                            g.Trim();

                            if(!lstBoxMovieGenres.Items.Contains(g))
                            {
                                lstBoxMovieGenres.Items.Add(g);
                            }

                        }
                    }

                }
            }
        }
    }
}
