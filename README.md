# SongApplication

This is a technical test
For a full test break down please view InteractWithAPIs.pdf included in the repository

The application takes in your favourite band or artists name (i.e prince) and will find out what the average numbers of words in their songs is.

## Cloning the repo

Clone the repo using: https://github.com/loofunk/SongApplication.git

## Running the application

1. Open the project in Visual Studio by opening SongApplication/SongAppication.sln
2. Ensure "SongApplication" is set as your start up project
3. Right click at the top of the solution and click "Restore Nuget Packages" - this will restore the Nuget Packages required to run the project
4. Click the play button
5. The project should load up a console window with instructions on what to do
6. Type in your favourite artists name in (i.e prince) 
7. Hit the Enter button
8. The program will now communicate with the services
9. You will be presented with the average numbers of words in the songs of your favourite artist

## API's used:

1. MusicBrainz - https://musicbrainz.org/doc/MusicBrainz_API

2. LyricsOvh - https://lyricsovh.docs.apiary.io/#reference

## API formatting

If you wish to use the API's in your own system simply follow these instructions:

1. Make a query to the API using an artist: https://musicbrainz.org/ws/2/release/?query=artist:prince&fmt=json

2. Get album information back for an artist using the release ID from above https://musicbrainz.org/ws/2/release/ee03b2c8-aa0e-44eb-bd4f-70fe17a3012a?inc=recordings&fmt=json
 
3. Get Lyrics information using the Artist name and track name: https://private-anon-adac4b5c4c-lyricsovh.apiary-proxy.com/v1/Prince/Hot%20thing