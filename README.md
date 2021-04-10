# MestoFix

[![forthebadge](https://forthebadge.com/images/badges/built-for-android.svg)](https://forthebadge.com) [![forthebadge](https://forthebadge.com/images/badges/ctrl-c-ctrl-v.svg)](https://forthebadge.com) [![forthebadge](https://forthebadge.com/images/badges/it-works-why.svg)](https://forthebadge.com) [![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com) 

## Description
* Application is suposted to be used for reporting problems in city.
* Everyone can report problems.

## Features
* Unicate UUID code instead of login system,
* QR code to access old device account on new device,
* Collecting IP address for 5 minutes to avoid DDOS attacks,
* Banning IP adress if necessary,
* Adding problems,
* Comment system,
* Like/dislike system,
* Reputation system,
* Dark and light mode (takes system mode),
* Showing nearest problems for basic users,
* Showing problems in city for city represenative users,
* Search by location,
* Search by region,
* Profile info,
* User settings:
   * QR code generating,
   * Setting name,
   * Setting surname,
   * Setting city,
   * Notification settings.

## API
|Type|URI|Description|Arguments|Returns|
|--|--|--|--|--|
|GET|`/GetData.php`|Gets data from 10km around|`lat` - Latitude, `longy` - longitude|HTTP 2.0 / JSON|
|GET|`/GetUserData.php`|Gets data about one specific UUID|`UUID` - UUID of user requesting, `ReqUUID` - UUID of user that request data, `AUTH` - OTP Token|HTTP 2.0 / JSON |
|GET|`/GetUserPosts.php`|Gets all posts about one specific UUID|`UUID` - UUID of user requesting, `ReqUUID` - UUID of user that request data|HTTP 2.0 / JSON|
|PUT|`/PushData.php`|Sends problem into database|`UUID` - UUID of user, `title` - String of title of problem, `description` - Description of problem - string, `lat` - Latitude of problem, `long` - Longitude of problem, `IMG` - Image in base64 string (may change), `auth` - OTP Auth Token |HTTP 2.0 / JSON|

## Changelog
```
Lastest Commit : 12.3.2020 22:30
+ Data Store
+ Developer Flags
+ OAUTH Check
- Cleanup
```
