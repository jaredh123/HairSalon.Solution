|<img src="https://github.com/identicons/jaredh123.png" width=100 alt="GitHub identicon for author jaredh123">|
|:-----:|
| [**jaredh123**](https://github.com/jaredh123 ) |

##  **HairSalon.Solution**

#### Epicodus independent project: HairSalon.Solution parts 1 and 2, created March 1st, 2019
#### By Jared Hanson

----------

## Description

A hair salon database that allows the additions and deletions of stylists, clients, and specialties using C# and MySql.

## Known Bugs

* No known bugs.

## Specifications
Have the database properly saved and the website running. The user is then allowed to click the available buttons and hyperlinks to access and fill in information on the stylists, clients, specialties, and the relationships between these aspects. All pages have a link back to the main home page.

| Behavior | Input | Output |
|----------|:-----:|:------:|
| User clicks "View/add stylists and add clients" link. | Click | Page redirect to stylist page to add or clear stylists. |
| User can then also access and edit stylist info, create clients, or add specialties. | Click/type | stylist info and/or clients, and/or specialties were accessed, created, or edited. |
| User clicks "View clients" link. | Click | Page redirect to client page to show or clear clients. |
| User clicks client name if present. | Click | Page redirect to client info page to show info, add stylist, edit client info, or delete client. |
| User clicks "View specialties" link. | Click | Page redirect to specialties page to show specialties, add specialties, or clear all specialties. |
| User clicks specialty if present. | Click | Page redirects to page to show stylists that have this specialty, to add stylists to specialty, and to delete specialty. |

## Setup and Use
Software Requirements:
Download .NET Core 1.1.4 SDK and .NET Core Runtime 1.1.2 and install them. Download Mono and install it. Download MAMP and install it.

* Clone this repository [repo](https://github.com/jaredh123/HairSalon.Solution): "$ git clone https://github.com/jaredh123/HairSalon.Solution "
* To edit the project, open the project in your preferred text editor.
* To run the program, in terminal first navigate to the location of the the HairSalon and HairSalon.Tests directories at the top levels and execute: "$ dotnet restore" in both directories.
* Open MAMP.
* Go to "http://localhost:8888/phpMyAdmin/server_import.php"
* Choose the files named jared_hanson.sql and jared_hanson_test.sql and import them.
* Then navigate to the HairSalon directory and execute commands: "$ dotnet build" and "$ dotnet run".
* Then go to "http://localhost:5000" to view webpage.

#### Prerequisites
* Must have a working browser, IDE, and terminal.
* Must have basic computer use proficiency

## Built With

* Atom (IDE)
* C#
* .NET
* Git
* MAMP
* MySql
* MyPHPAdmin

## Contributors

| Author | GitHub | Email |
|--------|:------:|:-----:|
| Jared Hanson | [jaredh123](https://github.com/jaredh123) | [jared.hanson12345@gmail.com](mailto:jared.hanson12345@gmail.com) |

## Support and contact details

If you have any feedback or concerns, please contact me at [jared.hanson12345@gmail.com](mailto:jared.hanson12345@gmail.com).

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT). Copyright (C) 2019 Jared Hanson. All Rights Reserved. MIT License

Copyright (c) 2019 [Jared Hanson](https://github.com/jaredh123)
