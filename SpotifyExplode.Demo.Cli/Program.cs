using System;
using System.Threading.Tasks;
using SpotifyExplode;
using SpotifyExplode.Search;
using SpotifyExplode.Tracks;

namespace SpotifyExplode.DemoConsole;

public static class Program
{
    static async Task Main(string[] args)
    {
        Console.Title = "SpotifyExplode Demo";

        await SpotifyTrack();
        await SpotifyPlaylist();
        await SpotifyAlbum();
        await SpotifyUser();
    }

    public static async Task SpotifyTrack()
    {
        var spotify = new SpotifyClient();

        // Get the track ID
        Console.Write("Enter Spotify track ID or URL: ");
        try
        {
            var trackId = TrackId.Parse(Console.ReadLine() ?? "");
            var track = await spotify.Tracks.GetAsync(trackId);

            Console.WriteLine($"Title: {track.Title}");
            Console.WriteLine($"Duration (milliseconds): {track.DurationMs}");
            Console.WriteLine($"{track.Album}");
        }
        catch { return; }
    }

    public static async Task SpotifyPlaylist()
    {
        var spotify = new SpotifyClient();

        Console.Write("Enter Spotify Playlist URL: ");
        var url = Console.ReadLine() ?? "";

        var playlist = await spotify.Playlists.GetAsync(url);

        Console.WriteLine($"Title: {playlist.Title}");
        Console.WriteLine($"Images: {playlist.Images}");
        Console.ReadLine();
    }

    public static async Task SpotifyAlbum()
    {
        var spotify = new SpotifyClient();

        Console.Write("Enter Spotify Album URL: ");
        var url = Console.ReadLine() ?? "";

        var album = await spotify.Albums.GetAsync(url);

        Console.WriteLine($"Title: {album.Title}");
        Console.WriteLine($"Images: {album.Images}");
        Console.ReadLine();
    }

    public static async Task SpotifyUser()
    {
        var spotify = new SpotifyClient();

        Console.Write("Enter Spotify User URL: ");
        var url = Console.ReadLine() ?? "";

        var user = await spotify.Users.GetAsync(url);

        Console.WriteLine($"Title: {user.DisplayName}");
        Console.WriteLine($"Images: {user.Images}");
        Console.ReadLine();
    }
}