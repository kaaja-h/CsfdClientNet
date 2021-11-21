# CsfdClientNet
Client for www.csfd.cz

## Features

- Search for movies.
- Search fro movie creatores
- Read data about movie
  - Rating
  - Plot
  - Creators
- Read data about creator
  - biography
  - filmography

## Usage
``` c#
  var client = new CsfdClient();
  //  find movies
  var movies = await client.FindMovies("Hra");
  // get movie detail
  var movieDetail = await client.GetMovieDetail(movies[0]);
  // find creator 
  var creators = await client.FindCreator("Boris");
  // get creator detail
  var creatorDetail = await client.GetCreatorDetail(creators[0]);
```

## Api
Api can be found [here](api/CsfdClientNet.md)

## TODO
- read new attributes
- epizodes support
- better unit tests
- suggestions