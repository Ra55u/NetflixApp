using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Collections.ObjectModel;
using Services;

namespace ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly TmdbService _tmdbService;
        public HomeViewModel(TmdbService tmdbService) 
        {
            _tmdbService = tmdbService;
        }
        [ObservableProperty]
        private Media _trendingMovie;

        public ObservableCollection<Media> Trending { get; set; } = new();
        public ObservableCollection<Media> TopRated { get; set; } = new();
        public ObservableCollection<Media> NetflixOriginals { get; set; } = new();
        public ObservableCollection<Media> Action { get; set; } = new();

        public async Task InitializeAsync()
        {
            var trendingList = await _tmdbService.GetTrendingAsync();
            if (trendingList?.Any() == true) 
            { 
                foreach (var trending in trendingList)
                {
                    Trending.Add(trending);
                }
            }

            var netflixOriginals = await _tmdbService.GetNetflixOriginalAsync();
            if(netflixOriginals?.Any() == true)
            {
                foreach (var original in netflixOriginals)
                {
                    NetflixOriginals.Add(original);
                }
            }
        }
    }
}
