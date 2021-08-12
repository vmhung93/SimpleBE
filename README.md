# Simple Back-End

## Description

This is an simple RESTful API to manage users. 

The admin has to sign in to the back office side. After sign-in successful, the admin can retrieve the list of users and add/update/delete the user.

*About the update/delete an user, I will impletement later.*

## Technical applied
- ASP.Net Core Web API
- ASP.NET Core Identity
- Authentication: JSON Web Tokens
- Swagger

## Before you start
You need to have an Admin first. Send the request to the URI below to create an Admin. 

```
[POST] ​/user​/seed 
```

## API list
Since I applied Swagger for API document, so you can take a look at Swagger documents for more information.

https://localhost:5001/swagger/index.html

## Testing user
You can use account below for testing:

UserName: admin

Password: handsome@2021
