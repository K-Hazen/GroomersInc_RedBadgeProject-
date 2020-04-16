# Groomers Inc.
## Red Badge Project for Eleven Fifty

This app is designed as a basic scheduling application for a dog grooming business.

## Table of Contents
* [Introduction](#introduction)
* [Technologies](#technologies)
* [Installation](#installation)
* [Functions](#functions)
* [Resources](#resources)


## Introduction
This class project was designed to give us hands on experience building out a .NET MVC application, n-tier architecture, working with foriegn keys, and using github as version control. The idea for the project came after seeing my folks continually have to call their groomer to schedule an appointment. 

The goal was to provide an app that had feature for both a customer and shop owner. For the customer the objective was to allow them to create a profile, add their pets, and schedule an appointment. On the shop owner side of things and Admin section was setup for them to manage user roles, customers, appointments, and employees. 

## Technologies 
Project is created with:
* .Net Framework - ASP.Net Web Application
* C# 
* Created in Visual Studio
* GitHub was used as a version control tool


## Installation
To run this application 
```
1. Click on this link: https://github.com/K-Hazen/GroomersInc_RedBadgeProject-.git
2. Go to the "clone/download" and pick the option you would like
3. If you choose to run in Visual Studio
      - Open the start window 
      - Click the "Clone or check out code" option
      - Paste in the link in the "Respository Location" box 
 4. NuGet Pacakges to install
      - Note - Bootstrap comes installed the MVC template but, at the time of writing this, it only ran version 3.4.1
      - Microsoft.Asp.Net.Identity.EntityFramework
      - Newtonsoft.Json (this allows you to display enum names)
 5. Access
      - To see Admin side of things log on with 
            - Admin username: bossPerson        
            - Password: Password1!
      - To see User side just register a new user 

## Functions
- For Admin Users
  - Create/Update/Delete customers, appointments, pets, and employees
  - Add and assign User Roles
  - Book appointments 
  
- For Customer
  - Register
  - Create profile and add pets
  - Search for appointment by date 
  - Book an appointment 
      
- Viewing options include:
  - Admin
    - See all customers, employess, and pets 
    - See all user roles
    - See booked appointments on pet and customer profile pages
    
  - Customers
    - See all pets
    - See booked appointments by viewing customer or pet profile 

## Resources
  
- Displaying value of an Enum instead of the index number: [Json Converter](https://exceptionnotfound.net/serializing-enumerations-in-asp-net-web-api/)

- Getting all values inside an Enum in ASP.NET Web API: [Returning Enum Values](https://exceptionnotfound.net/getting-all-valid-enum-values-in-asp-net-web-api/)

- [Creating User Roles](https://www.c-sharpcorner.com/UploadFile/asmabegam/Asp-Net-mvc-5-security-and-creating-user-role/)

- [Filtering User Roles](https://www.c-sharpcorner.com/UploadFile/rahul4_saxena/role-based-access-of-an-mvc-application/)

- [Displying Friendly Enum Names](https://www.codingame.com/playgrounds/2487/c---how-to-display-friendly-names-for-enumerations)

- [Using Data Annotations](https://www.c-sharpcorner.com/article/model-validation-using-data-annotations-in-asp-net-mvc/)

- [Display Date in Editing View](https://stackoverflow.com/questions/31993584/asp-net-mvc-apply-different-displayformats-for-edit-and-display-modes)


