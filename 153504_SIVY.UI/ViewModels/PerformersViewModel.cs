﻿using System.Collections.ObjectModel;
using _153504_SIVY.Domain.Entities;
using _153504_SIVY.MyApplication.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _153504_SIVY.UI.ViewModels
{
    public partial class PerformersViewModel : ObservableObject
    {
        private readonly IPerformerService _performerService;
        private readonly ISongService _songService;

        public ObservableCollection<Song> Songs { get; set; } = new();
        public ObservableCollection<Performer> Performers { get; set; } = new();

        [ObservableProperty]
        Performer selectedPerformer;

        [RelayCommand]
        async void UpdatePerformerList() => await GetPerformers();

        [RelayCommand]
        async void UpdateSongList() => await GetSongs();
        public PerformersViewModel(IPerformerService performerService, ISongService songService)
        {
            _performerService = performerService;
            _songService = songService;
        }

        public async Task GetPerformers()
        {
            var performers = await _performerService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Performers.Clear();
                foreach (var performer in performers)
                {
                    Performers.Add(performer);
                }
            });
        }

        public async Task GetSongs()
        {
            var songs = await _songService.GetPerformerSongs(SelectedPerformer.Id);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Songs.Clear();
                foreach(var song in songs)
                {
                    Songs.Add(song);
                }
            });
        }
    }
}