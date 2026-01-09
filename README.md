# 🩸 BloodLink – Blood Donation Management System

BloodLink is a web-based Blood Donation Management System built using **ASP.NET Core MVC** and **Entity Framework Core**.  
It helps connect blood donors with people in need of blood in a fast, secure, and organized way.

## Features

- Register blood donors  
- Create blood requests  
- Search donors by blood group  
- Store and manage records in a database  
- Simple and user-friendly web interface
  
## Technologies Used

- ASP.NET Core MVC (.NET 8)  
- Entity Framework Core  
- SQL Server / LocalDB  
- Razor Views  
- Bootstrap, HTML, CSS  
- C#
  
## Project Structure

BloodLink
- Controllers/
   - HomeController.cs
   - DonorController.cs
   - RequestController.cs

- Models/
   - Donor.cs
   - BloodRequest.cs
   - ErrorViewModel.cs

- Data/
   - AppDbContext.cs

- Views/
   - (Razor Pages for UI)
   - Home
   - Donor
   - Request

- appsettings.json
- BloodLink.csproj
- Program.cs

## Setup & Run

1. Open the project in **Visual Studio**
2. Configure the database in `appsettings.json`
3. Run migrations:
      "ConnectionStrings": {
        "DefaultConnection": "Server=servername;Database=BloodLinkDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
   }

## Project Objective

To provide a digital platform that helps hospitals and patients find blood donors quickly and efficiently.

## Future Improvements

- Donor availability tracking
- SMS / Email alerts
- Admin dashboard
- Mobile app integration

## Developer

Fatima Bibi

## Contributors

- Aiman Fareed
- Anzala
