<a name='assembly'></a>
# CsfdClientNet

## Contents

- [Creator](#T-CsfdClientNet-Data-Creator 'CsfdClientNet.Data.Creator')
  - [Id](#P-CsfdClientNet-Data-Creator-Id 'CsfdClientNet.Data.Creator.Id')
  - [Name](#P-CsfdClientNet-Data-Creator-Name 'CsfdClientNet.Data.Creator.Name')
- [CreatorDetail](#T-CsfdClientNet-Data-CreatorDetail 'CsfdClientNet.Data.CreatorDetail')
  - [Biography](#P-CsfdClientNet-Data-CreatorDetail-Biography 'CsfdClientNet.Data.CreatorDetail.Biography')
  - [Creator](#P-CsfdClientNet-Data-CreatorDetail-Creator 'CsfdClientNet.Data.CreatorDetail.Creator')
- [CsfdClient](#T-CsfdClientNet-CsfdClient 'CsfdClientNet.CsfdClient')
  - [#ctor()](#M-CsfdClientNet-CsfdClient-#ctor 'CsfdClientNet.CsfdClient.#ctor')
  - [#ctor(options)](#M-CsfdClientNet-CsfdClient-#ctor-CsfdClientNet-CsfdClientOptions- 'CsfdClientNet.CsfdClient.#ctor(CsfdClientNet.CsfdClientOptions)')
  - [FindCreator(name,useCache)](#M-CsfdClientNet-CsfdClient-FindCreator-System-String,System-Boolean- 'CsfdClientNet.CsfdClient.FindCreator(System.String,System.Boolean)')
  - [FindCreator(name,token,useCache)](#M-CsfdClientNet-CsfdClient-FindCreator-System-String,System-Threading-CancellationToken,System-Boolean- 'CsfdClientNet.CsfdClient.FindCreator(System.String,System.Threading.CancellationToken,System.Boolean)')
  - [FindMovies(name,useCache)](#M-CsfdClientNet-CsfdClient-FindMovies-System-String,System-Boolean- 'CsfdClientNet.CsfdClient.FindMovies(System.String,System.Boolean)')
  - [FindMovies(name,token,useCache)](#M-CsfdClientNet-CsfdClient-FindMovies-System-String,System-Threading-CancellationToken,System-Boolean- 'CsfdClientNet.CsfdClient.FindMovies(System.String,System.Threading.CancellationToken,System.Boolean)')
  - [GetCreatorDetail(creator,useCache)](#M-CsfdClientNet-CsfdClient-GetCreatorDetail-CsfdClientNet-Data-Creator,System-Boolean- 'CsfdClientNet.CsfdClient.GetCreatorDetail(CsfdClientNet.Data.Creator,System.Boolean)')
  - [GetCreatorDetail(creator,token,useCache)](#M-CsfdClientNet-CsfdClient-GetCreatorDetail-CsfdClientNet-Data-Creator,System-Threading-CancellationToken,System-Boolean- 'CsfdClientNet.CsfdClient.GetCreatorDetail(CsfdClientNet.Data.Creator,System.Threading.CancellationToken,System.Boolean)')
  - [GetMovieDetail(movie,useCache)](#M-CsfdClientNet-CsfdClient-GetMovieDetail-CsfdClientNet-Data-Movie,System-Boolean- 'CsfdClientNet.CsfdClient.GetMovieDetail(CsfdClientNet.Data.Movie,System.Boolean)')
  - [GetMovieDetail(movie,token,useCache)](#M-CsfdClientNet-CsfdClient-GetMovieDetail-CsfdClientNet-Data-Movie,System-Threading-CancellationToken,System-Boolean- 'CsfdClientNet.CsfdClient.GetMovieDetail(CsfdClientNet.Data.Movie,System.Threading.CancellationToken,System.Boolean)')
- [CsfdClientOptions](#T-CsfdClientNet-CsfdClientOptions 'CsfdClientNet.CsfdClientOptions')
  - [Cache](#P-CsfdClientNet-CsfdClientOptions-Cache 'CsfdClientNet.CsfdClientOptions.Cache')
  - [LoggerFactory](#P-CsfdClientNet-CsfdClientOptions-LoggerFactory 'CsfdClientNet.CsfdClientOptions.LoggerFactory')
  - [RequestDelay](#P-CsfdClientNet-CsfdClientOptions-RequestDelay 'CsfdClientNet.CsfdClientOptions.RequestDelay')
- [ICsfdClientCache](#T-CsfdClientNet-Cache-ICsfdClientCache 'CsfdClientNet.Cache.ICsfdClientCache')
  - [FindCreatorByName(name,token)](#M-CsfdClientNet-Cache-ICsfdClientCache-FindCreatorByName-System-String,System-Threading-CancellationToken- 'CsfdClientNet.Cache.ICsfdClientCache.FindCreatorByName(System.String,System.Threading.CancellationToken)')
  - [FindMovieByName(name,token)](#M-CsfdClientNet-Cache-ICsfdClientCache-FindMovieByName-System-String,System-Threading-CancellationToken- 'CsfdClientNet.Cache.ICsfdClientCache.FindMovieByName(System.String,System.Threading.CancellationToken)')
  - [GetCreatorDetail(id,token)](#M-CsfdClientNet-Cache-ICsfdClientCache-GetCreatorDetail-System-String,System-Threading-CancellationToken- 'CsfdClientNet.Cache.ICsfdClientCache.GetCreatorDetail(System.String,System.Threading.CancellationToken)')
  - [GetMovieDetail(id,token)](#M-CsfdClientNet-Cache-ICsfdClientCache-GetMovieDetail-System-String,System-Threading-CancellationToken- 'CsfdClientNet.Cache.ICsfdClientCache.GetMovieDetail(System.String,System.Threading.CancellationToken)')
  - [SaveCreator(creator,token)](#M-CsfdClientNet-Cache-ICsfdClientCache-SaveCreator-CsfdClientNet-Data-Creator,System-Threading-CancellationToken- 'CsfdClientNet.Cache.ICsfdClientCache.SaveCreator(CsfdClientNet.Data.Creator,System.Threading.CancellationToken)')
  - [SaveCreatorDetail(detail,token)](#M-CsfdClientNet-Cache-ICsfdClientCache-SaveCreatorDetail-CsfdClientNet-Data-CreatorDetail,System-Threading-CancellationToken- 'CsfdClientNet.Cache.ICsfdClientCache.SaveCreatorDetail(CsfdClientNet.Data.CreatorDetail,System.Threading.CancellationToken)')
  - [SaveMovie(movie,token)](#M-CsfdClientNet-Cache-ICsfdClientCache-SaveMovie-CsfdClientNet-Data-Movie,System-Threading-CancellationToken- 'CsfdClientNet.Cache.ICsfdClientCache.SaveMovie(CsfdClientNet.Data.Movie,System.Threading.CancellationToken)')
  - [SaveMovieDetail(movieDetail,token)](#M-CsfdClientNet-Cache-ICsfdClientCache-SaveMovieDetail-CsfdClientNet-Data-MovieDetail,System-Threading-CancellationToken- 'CsfdClientNet.Cache.ICsfdClientCache.SaveMovieDetail(CsfdClientNet.Data.MovieDetail,System.Threading.CancellationToken)')
- [MemoryCache](#T-CsfdClientNet-Cache-MemoryCache 'CsfdClientNet.Cache.MemoryCache')
  - [#ctor(liveTime)](#M-CsfdClientNet-Cache-MemoryCache-#ctor-System-TimeSpan- 'CsfdClientNet.Cache.MemoryCache.#ctor(System.TimeSpan)')
  - [FindCreatorByName()](#M-CsfdClientNet-Cache-MemoryCache-FindCreatorByName-System-String,System-Threading-CancellationToken- 'CsfdClientNet.Cache.MemoryCache.FindCreatorByName(System.String,System.Threading.CancellationToken)')
  - [FindMovieByName()](#M-CsfdClientNet-Cache-MemoryCache-FindMovieByName-System-String,System-Threading-CancellationToken- 'CsfdClientNet.Cache.MemoryCache.FindMovieByName(System.String,System.Threading.CancellationToken)')
  - [GetCreatorDetail()](#M-CsfdClientNet-Cache-MemoryCache-GetCreatorDetail-System-String,System-Threading-CancellationToken- 'CsfdClientNet.Cache.MemoryCache.GetCreatorDetail(System.String,System.Threading.CancellationToken)')
  - [GetMovieDetail()](#M-CsfdClientNet-Cache-MemoryCache-GetMovieDetail-System-String,System-Threading-CancellationToken- 'CsfdClientNet.Cache.MemoryCache.GetMovieDetail(System.String,System.Threading.CancellationToken)')
  - [SaveCreator()](#M-CsfdClientNet-Cache-MemoryCache-SaveCreator-CsfdClientNet-Data-Creator,System-Threading-CancellationToken- 'CsfdClientNet.Cache.MemoryCache.SaveCreator(CsfdClientNet.Data.Creator,System.Threading.CancellationToken)')
  - [SaveCreatorDetail()](#M-CsfdClientNet-Cache-MemoryCache-SaveCreatorDetail-CsfdClientNet-Data-CreatorDetail,System-Threading-CancellationToken- 'CsfdClientNet.Cache.MemoryCache.SaveCreatorDetail(CsfdClientNet.Data.CreatorDetail,System.Threading.CancellationToken)')
  - [SaveMovie()](#M-CsfdClientNet-Cache-MemoryCache-SaveMovie-CsfdClientNet-Data-Movie,System-Threading-CancellationToken- 'CsfdClientNet.Cache.MemoryCache.SaveMovie(CsfdClientNet.Data.Movie,System.Threading.CancellationToken)')
  - [SaveMovieDetail()](#M-CsfdClientNet-Cache-MemoryCache-SaveMovieDetail-CsfdClientNet-Data-MovieDetail,System-Threading-CancellationToken- 'CsfdClientNet.Cache.MemoryCache.SaveMovieDetail(CsfdClientNet.Data.MovieDetail,System.Threading.CancellationToken)')
- [Movie](#T-CsfdClientNet-Data-Movie 'CsfdClientNet.Data.Movie')
  - [Id](#P-CsfdClientNet-Data-Movie-Id 'CsfdClientNet.Data.Movie.Id')
  - [Name](#P-CsfdClientNet-Data-Movie-Name 'CsfdClientNet.Data.Movie.Name')
  - [Year](#P-CsfdClientNet-Data-Movie-Year 'CsfdClientNet.Data.Movie.Year')
- [MovieDetail](#T-CsfdClientNet-Data-MovieDetail 'CsfdClientNet.Data.MovieDetail')
  - [DateCreated](#P-CsfdClientNet-Data-MovieDetail-DateCreated 'CsfdClientNet.Data.MovieDetail.DateCreated')
  - [Genres](#P-CsfdClientNet-Data-MovieDetail-Genres 'CsfdClientNet.Data.MovieDetail.Genres')
  - [Length](#P-CsfdClientNet-Data-MovieDetail-Length 'CsfdClientNet.Data.MovieDetail.Length')
  - [Movie](#P-CsfdClientNet-Data-MovieDetail-Movie 'CsfdClientNet.Data.MovieDetail.Movie')
  - [Origin](#P-CsfdClientNet-Data-MovieDetail-Origin 'CsfdClientNet.Data.MovieDetail.Origin')
  - [Plots](#P-CsfdClientNet-Data-MovieDetail-Plots 'CsfdClientNet.Data.MovieDetail.Plots')
  - [Professions](#P-CsfdClientNet-Data-MovieDetail-Professions 'CsfdClientNet.Data.MovieDetail.Professions')
  - [RatingAverage](#P-CsfdClientNet-Data-MovieDetail-RatingAverage 'CsfdClientNet.Data.MovieDetail.RatingAverage')
  - [RatingCount](#P-CsfdClientNet-Data-MovieDetail-RatingCount 'CsfdClientNet.Data.MovieDetail.RatingCount')

<a name='T-CsfdClientNet-Data-Creator'></a>
## Creator `type`

##### Namespace

CsfdClientNet.Data

##### Summary

Movie creator

<a name='P-CsfdClientNet-Data-Creator-Id'></a>
### Id `property`

##### Summary

Creator ID (csfd URL part)

<a name='P-CsfdClientNet-Data-Creator-Name'></a>
### Name `property`

##### Summary

Creator name

<a name='T-CsfdClientNet-Data-CreatorDetail'></a>
## CreatorDetail `type`

##### Namespace

CsfdClientNet.Data

##### Summary

Creator detail

<a name='P-CsfdClientNet-Data-CreatorDetail-Biography'></a>
### Biography `property`

##### Summary

Creator biography

<a name='P-CsfdClientNet-Data-CreatorDetail-Creator'></a>
### Creator `property`

##### Summary

Creator

<a name='T-CsfdClientNet-CsfdClient'></a>
## CsfdClient `type`

##### Namespace

CsfdClientNet

##### Summary

Csfd client

<a name='M-CsfdClientNet-CsfdClient-#ctor'></a>
### #ctor() `constructor`

##### Summary

constructor with default options

##### Parameters

This constructor has no parameters.

<a name='M-CsfdClientNet-CsfdClient-#ctor-CsfdClientNet-CsfdClientOptions-'></a>
### #ctor(options) `constructor`

##### Summary

constructor with option settings

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| options | [CsfdClientNet.CsfdClientOptions](#T-CsfdClientNet-CsfdClientOptions 'CsfdClientNet.CsfdClientOptions') |  |

<a name='M-CsfdClientNet-CsfdClient-FindCreator-System-String,System-Boolean-'></a>
### FindCreator(name,useCache) `method`

##### Summary

find creator by name

##### Returns

Creators list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | creator name |
| useCache | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | use cache |

<a name='M-CsfdClientNet-CsfdClient-FindCreator-System-String,System-Threading-CancellationToken,System-Boolean-'></a>
### FindCreator(name,token,useCache) `method`

##### Summary

find creator by name

##### Returns

Creators list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | creator name |
| token | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | async cancellation token |
| useCache | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | use cache |

<a name='M-CsfdClientNet-CsfdClient-FindMovies-System-String,System-Boolean-'></a>
### FindMovies(name,useCache) `method`

##### Summary

Find movies by name

##### Returns

movie list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | movie name |
| useCache | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | use cache |

<a name='M-CsfdClientNet-CsfdClient-FindMovies-System-String,System-Threading-CancellationToken,System-Boolean-'></a>
### FindMovies(name,token,useCache) `method`

##### Summary

Find movies by name

##### Returns

movie list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | movie name |
| token | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | async cancelation token |
| useCache | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | use cache |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') |  |

<a name='M-CsfdClientNet-CsfdClient-GetCreatorDetail-CsfdClientNet-Data-Creator,System-Boolean-'></a>
### GetCreatorDetail(creator,useCache) `method`

##### Summary

Get creator detail

##### Returns

Creator detail

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| creator | [CsfdClientNet.Data.Creator](#T-CsfdClientNet-Data-Creator 'CsfdClientNet.Data.Creator') | creator |
| useCache | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | use cache |

<a name='M-CsfdClientNet-CsfdClient-GetCreatorDetail-CsfdClientNet-Data-Creator,System-Threading-CancellationToken,System-Boolean-'></a>
### GetCreatorDetail(creator,token,useCache) `method`

##### Summary

Get creator detail

##### Returns

Creator detail

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| creator | [CsfdClientNet.Data.Creator](#T-CsfdClientNet-Data-Creator 'CsfdClientNet.Data.Creator') | creator |
| token | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | async cancellation token |
| useCache | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | use cache |

<a name='M-CsfdClientNet-CsfdClient-GetMovieDetail-CsfdClientNet-Data-Movie,System-Boolean-'></a>
### GetMovieDetail(movie,useCache) `method`

##### Summary

Get movie detail

##### Returns

Movie detail

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| movie | [CsfdClientNet.Data.Movie](#T-CsfdClientNet-Data-Movie 'CsfdClientNet.Data.Movie') | movie for detail |
| useCache | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | use cache |

<a name='M-CsfdClientNet-CsfdClient-GetMovieDetail-CsfdClientNet-Data-Movie,System-Threading-CancellationToken,System-Boolean-'></a>
### GetMovieDetail(movie,token,useCache) `method`

##### Summary

Get movie detail

##### Returns

Movie detail

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| movie | [CsfdClientNet.Data.Movie](#T-CsfdClientNet-Data-Movie 'CsfdClientNet.Data.Movie') | movie for detail |
| token | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | async cancellation token |
| useCache | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | use cache |

<a name='T-CsfdClientNet-CsfdClientOptions'></a>
## CsfdClientOptions `type`

##### Namespace

CsfdClientNet

##### Summary

Csfd client options

<a name='P-CsfdClientNet-CsfdClientOptions-Cache'></a>
### Cache `property`

##### Summary

Cleint cache, Default MemoryCache [MemoryCache](#T-CsfdClientNet-Cache-MemoryCache 'CsfdClientNet.Cache.MemoryCache')

<a name='P-CsfdClientNet-CsfdClientOptions-LoggerFactory'></a>
### LoggerFactory `property`

##### Summary

Logger factory

<a name='P-CsfdClientNet-CsfdClientOptions-RequestDelay'></a>
### RequestDelay `property`

##### Summary

Delay between requests

<a name='T-CsfdClientNet-Cache-ICsfdClientCache'></a>
## ICsfdClientCache `type`

##### Namespace

CsfdClientNet.Cache

##### Summary

Csfd data Cache interface

<a name='M-CsfdClientNet-Cache-ICsfdClientCache-FindCreatorByName-System-String,System-Threading-CancellationToken-'></a>
### FindCreatorByName(name,token) `method`

##### Summary

Find creator by name

##### Returns

list of creators

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | creator name |
| token | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | async cancellation token |

<a name='M-CsfdClientNet-Cache-ICsfdClientCache-FindMovieByName-System-String,System-Threading-CancellationToken-'></a>
### FindMovieByName(name,token) `method`

##### Summary

Finds movie by name

##### Returns

list of movies

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | movie name |
| token | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | async cancellation token |

<a name='M-CsfdClientNet-Cache-ICsfdClientCache-GetCreatorDetail-System-String,System-Threading-CancellationToken-'></a>
### GetCreatorDetail(id,token) `method`

##### Summary



##### Returns

creator detail

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | creator id |
| token | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | async cancellation token |

<a name='M-CsfdClientNet-Cache-ICsfdClientCache-GetMovieDetail-System-String,System-Threading-CancellationToken-'></a>
### GetMovieDetail(id,token) `method`

##### Summary

Get movie by detail

##### Returns

movie detail

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | movie id |
| token | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | async cancellation token |

<a name='M-CsfdClientNet-Cache-ICsfdClientCache-SaveCreator-CsfdClientNet-Data-Creator,System-Threading-CancellationToken-'></a>
### SaveCreator(creator,token) `method`

##### Summary

Save Creator to cache

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| creator | [CsfdClientNet.Data.Creator](#T-CsfdClientNet-Data-Creator 'CsfdClientNet.Data.Creator') | creator to save |
| token | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | async cancellation token |

<a name='M-CsfdClientNet-Cache-ICsfdClientCache-SaveCreatorDetail-CsfdClientNet-Data-CreatorDetail,System-Threading-CancellationToken-'></a>
### SaveCreatorDetail(detail,token) `method`

##### Summary

Save CreatorDetail to cache

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| detail | [CsfdClientNet.Data.CreatorDetail](#T-CsfdClientNet-Data-CreatorDetail 'CsfdClientNet.Data.CreatorDetail') | CreatorDetail to save |
| token | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | async cancellation token |

<a name='M-CsfdClientNet-Cache-ICsfdClientCache-SaveMovie-CsfdClientNet-Data-Movie,System-Threading-CancellationToken-'></a>
### SaveMovie(movie,token) `method`

##### Summary

Save movie to cache

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| movie | [CsfdClientNet.Data.Movie](#T-CsfdClientNet-Data-Movie 'CsfdClientNet.Data.Movie') | movie to save |
| token | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | async cancellation token |

<a name='M-CsfdClientNet-Cache-ICsfdClientCache-SaveMovieDetail-CsfdClientNet-Data-MovieDetail,System-Threading-CancellationToken-'></a>
### SaveMovieDetail(movieDetail,token) `method`

##### Summary

Save movie detail to cache

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| movieDetail | [CsfdClientNet.Data.MovieDetail](#T-CsfdClientNet-Data-MovieDetail 'CsfdClientNet.Data.MovieDetail') | movie detail to save |
| token | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | async cancellation token |

<a name='T-CsfdClientNet-Cache-MemoryCache'></a>
## MemoryCache `type`

##### Namespace

CsfdClientNet.Cache

##### Summary

In memory cache

<a name='M-CsfdClientNet-Cache-MemoryCache-#ctor-System-TimeSpan-'></a>
### #ctor(liveTime) `constructor`

##### Summary

constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| liveTime | [System.TimeSpan](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TimeSpan 'System.TimeSpan') | memory item livetime |

<a name='M-CsfdClientNet-Cache-MemoryCache-FindCreatorByName-System-String,System-Threading-CancellationToken-'></a>
### FindCreatorByName() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-CsfdClientNet-Cache-MemoryCache-FindMovieByName-System-String,System-Threading-CancellationToken-'></a>
### FindMovieByName() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-CsfdClientNet-Cache-MemoryCache-GetCreatorDetail-System-String,System-Threading-CancellationToken-'></a>
### GetCreatorDetail() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-CsfdClientNet-Cache-MemoryCache-GetMovieDetail-System-String,System-Threading-CancellationToken-'></a>
### GetMovieDetail() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-CsfdClientNet-Cache-MemoryCache-SaveCreator-CsfdClientNet-Data-Creator,System-Threading-CancellationToken-'></a>
### SaveCreator() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-CsfdClientNet-Cache-MemoryCache-SaveCreatorDetail-CsfdClientNet-Data-CreatorDetail,System-Threading-CancellationToken-'></a>
### SaveCreatorDetail() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-CsfdClientNet-Cache-MemoryCache-SaveMovie-CsfdClientNet-Data-Movie,System-Threading-CancellationToken-'></a>
### SaveMovie() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-CsfdClientNet-Cache-MemoryCache-SaveMovieDetail-CsfdClientNet-Data-MovieDetail,System-Threading-CancellationToken-'></a>
### SaveMovieDetail() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-CsfdClientNet-Data-Movie'></a>
## Movie `type`

##### Namespace

CsfdClientNet.Data

##### Summary

Csfd movie

<a name='P-CsfdClientNet-Data-Movie-Id'></a>
### Id `property`

##### Summary

Movie ID (csfd URL part)

<a name='P-CsfdClientNet-Data-Movie-Name'></a>
### Name `property`

##### Summary

Movie name

<a name='P-CsfdClientNet-Data-Movie-Year'></a>
### Year `property`

##### Summary

Movie year

<a name='T-CsfdClientNet-Data-MovieDetail'></a>
## MovieDetail `type`

##### Namespace

CsfdClientNet.Data

##### Summary

Movie detail

<a name='P-CsfdClientNet-Data-MovieDetail-DateCreated'></a>
### DateCreated `property`

##### Summary

Date created

<a name='P-CsfdClientNet-Data-MovieDetail-Genres'></a>
### Genres `property`

##### Summary

List of genres

<a name='P-CsfdClientNet-Data-MovieDetail-Length'></a>
### Length `property`

##### Summary

Movie length

<a name='P-CsfdClientNet-Data-MovieDetail-Movie'></a>
### Movie `property`

##### Summary

Movie

<a name='P-CsfdClientNet-Data-MovieDetail-Origin'></a>
### Origin `property`

##### Summary

Movie origin

<a name='P-CsfdClientNet-Data-MovieDetail-Plots'></a>
### Plots `property`

##### Summary

Movie plots

<a name='P-CsfdClientNet-Data-MovieDetail-Professions'></a>
### Professions `property`

##### Summary

Creator of movie sorted by profession

<a name='P-CsfdClientNet-Data-MovieDetail-RatingAverage'></a>
### RatingAverage `property`

##### Summary

Average rating (percent)

<a name='P-CsfdClientNet-Data-MovieDetail-RatingCount'></a>
### RatingCount `property`

##### Summary

Rating count
