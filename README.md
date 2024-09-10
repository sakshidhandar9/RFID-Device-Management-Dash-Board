# RFID-Device-Management-Dash-Board
Project Overview

The RFID Device Management Dashboard is a web application designed to facilitate the management and monitoring of RFID (Radio Frequency Identification) devices. It provides functionalities for registering new devices, viewing device details, monitoring RFID tag reads, updating device information, deleting devices, and tracking device statuses in real-time. This application is built using ASP.NET MVC, Entity Framework, and Bootstrap for a responsive user interface.

Features

Register RFID Devices: Add new RFID devices with details like device name, type, unique identifier, and location.
View Registered Devices: Display a list of all registered RFID devices with options for sorting, filtering, and searching.
Monitor RFID Tag Reads: Track and display the latest RFID tag reads, including timestamp, location, and reader ID, with access to historical data.
Update Device Information: Update existing RFID device details with validation to ensure unique identifiers.
Delete Devices: Remove RFID devices from the system.
Device Status Monitoring: Show real-time status of RFID readers (online/offline).
Basic Authentication: Secure access to the dashboard with user authentication.


Technical Requirements
Frontend: Razor views, HTML5, CSS3, JavaScript/jQuery, Bootstrap.
Backend: ASP.NET MVC with C#.
Database: SQL Server or any relational database, managed with Entity Framework.
Real-Time Updates (Optional): SignalR for real-time RFID tag reads and device status updates.
RFID Simulation: Mock data or random generation for RFID tag reads.
Setup and Installation
Clone the Repository:

bash
Copy code
git clone https://github.com/sakshidhandar9/rfid-device-management-dashboard.git
cd rfid-device-management-dashboard
Install Dependencies: Ensure you have the following installed:

.NET SDK
SQL Server
Restore the project dependencies:

bash
Copy code
dotnet restore

Configure Database:

Create a new database in SQL Server.
Update the connection string in web.config or appsettings.json with your database details.
Apply Migrations: Apply Entity Framework migrations to create the necessary database tables:

bash
Copy code
dotnet ef database update
Run the Application: Start the application using:

bash
Copy code
dotnet run
Navigate to https://localhost:5001 in your web browser to access the application.

Usage

Login: Use the login page to authenticate and access the dashboard.
Dashboard: Use the dashboard to manage RFID devices, view device details, and monitor real-time status.

Challenges Faced

Integrating SignalR: Faced challenges with implementing real-time updates for RFID tag reads and device statuses. Resolved by configuring SignalR hubs and ensuring proper connection handling.
Handling Real-Time Data: Managed real-time updates by using a combination of SignalR and periodic polling to simulate RFID tag reads and device status changes.
Additional Features
Real-Time Updates: Implemented SignalR for real-time updates on RFID tag reads and device status.
Enhanced UI: Improved the user interface with responsive design and modern styling using Bootstrap.
Contribution
Contributions are welcome! Please fork the repository and submit a pull request with your changes.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
For any inquiries or support, please contact your-sakshidhandar9@gmail.com
