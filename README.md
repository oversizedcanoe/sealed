# sealed
An anonymous survey/feedback web application.

## Goals for Project
- Create a full stack Angular + dotnet application for my portfolio
- Learn and use postgres
- Learn and use a different CSS framework besides Bootstrap
- Potentially deploy to AWS so I can learn how to deploy/run Angular/dotnet/postres on Linux
- Use best practices as much as possible in all parts of application

## Project outline/plan
1. Two options on landing screen: generate codes, or enter code.
2. When generating codes, the user is given two codes, a private and a public code.
3. The public code can be made public to employees, which allows users to anonymously post feedback in a form. They would do this via entering the code in the input in 1) or going to ````site.com/PUBLIC_CODE````.
4. Entering the private code/going to ````site.com/PRIVATE_CODE````
5. The private code allows the user to see all the public feedback, anonymously.
6. The private code is stored in the users local/session storage -- if they clear cache, it's gone forever. They can see previous private codes in the web view for easy access (however, the private code isn't shown, or only a portion of it is in case screenshots taken etc. Maybe just the public code).

A few other things:
1. The generating user could eventually add multiple different types of inputs/questions, but for now it could just be a single textbox (500 char limit).
2. The codes/links should get deleted after a set amount of time, maybe a month for now.
3. The generating user can delete/inactivate the link at any time (for example if it leaked).
4. Need to have some sort of security to prevent someone from calling the backend API outside of the web app.
5. Ensure that there are never any responses from the API with the private link -- should only ever be requests into the API with it.
