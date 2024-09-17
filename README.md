# sealed
An anonymous survey/feedback web application.

## Tech Breakdown
- The backend is a .NET Web API Project which uses EFCore as an ORM and to manage migrations.
  - The API is RateLimited to 10 requests to any POST endpoint per IP Address per day. In a production application, a more strict rate limiting approach would be needed, but this is just a hobby project. 
- The database I used is Postgres.
- The frontend is an Angular18 project
  - I used PureCSS, an extremely minimal CSS framework, as the CSS library.
  - I never claim to be a desginer :) 

## Functionality
- Users can create a pair of keys -- one private and one public.
- They can share the public key link with anyone, and anyone with the public link can submit anonymous data (feedback, reviews, etc.).
- Only the person with the private key can see the submitted data.
- Each key is a GUID, so it's guaranteed unique (for the next trillion years or so).

## Screenshots
Home page
![image](https://github.com/user-attachments/assets/53e0b956-390a-4e0c-9442-577b52f5c3f1)

After clicking "Generate Codes", the user can copy the Private Code for safe keeping, or copy the Public Code/Link for distribution.
![image](https://github.com/user-attachments/assets/b540e60a-f8da-4cd6-9dd5-67cf95387526)


After navigating to the created Public link, or entering the Public code on the home page, user can enter entries.
![image](https://github.com/user-attachments/assets/03884c31-860f-4565-a390-19f7f20ea0d0)

After entering a few values. These are only held in page memory as confirmation to the user; they disappear on page refresh.
![image](https://github.com/user-attachments/assets/e4b19f3a-630d-479d-ab88-6806818e9e01)

After entering the Private code on the home page, user can see entries.
![image](https://github.com/user-attachments/assets/1b4e7d5b-f355-4542-a6e8-20777b9cba55)




## Future Goals/Improvements
- The Keys and UserEntry data should purge itself after a month.
- The user should be able to save their created private keys to browser storage. By default the application is as secure as possible with respect to private keys (it removes them from storage immediately and purposely does not place them in the URL).
- The user should be able to permanently delete a private key/pair/it's associated entries -- for example if it is leaked.
- The Key and KeyPair table could be broken into a PrivateKey and PublicKey table, where each has a reference to eachother. This could improve query speed if the table ever got large.
- Deploy to AWS for fun. Should try to implement a reverse proxy.
