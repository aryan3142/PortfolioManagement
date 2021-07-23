# 👣 **Portfolio Management**

>## **Project Manager: Aryan Khandelwal**
>## ✍&nbsp; PROJECT OverView

A leading FinTech Services Organization wanted to strengthen its Middleware by 
exposing the core logic related to Portfolio Management as Microservices. This middle ware Microservices have also been hosted on Azure 
so that all the up/downstream applications can get an access to this for performing business transactions.
There is also be a customer Portal developed part of this project that consumes all of these Microservices to view their portfolio information and sell their assets.

### ⚡ Scope
- Share Price Microservice - 
  This is a Middleware Microservice that performs following operation: 
  · Get daily share price of a stocks listed in the user's portfolio.
- Mutual Fund Microservice - 
  This is a Middleware Microservice that performs following operation: 
  . Get NAV value of a Mutual Fund
- Calculate Net worth Microservice - 
  This is a Middleware Microservice that performs following operation: 
  . Calculate the current value of share holdings and mutual fund holdings and find out the total current value or net-worth 
  · Sell Assets and determine the final net-worth
- Customer Portal - 
  A Web Portal that allows a customer to Login and allows to do following operations:
  · Login 
  · View the portfolio holdings & networth 
  · Sell assets
- Authorization Microservice: - 
  . Service to Service communication has to happen using JWT
  . Pass End User Context across Microservices
  . Have the token expired after specific amount of time say 15 minutes
  . Have this service configured in the cloud along with other services
  
 ### ⚡ Features
 Documentation Requirements:
- All the Microservices are configured with Swagger for documentation
- Registerd the swagger resources in the Swagger Microservice and enabled them as REST end points
- Configured this service along with other services in the cloud (Azure)

### ⚡ Individual Components of the System
- [Authorization MicroService](https://github.com/ryan3142/PortfolioManagement/tree/main/Authorization)
- Share Price Microservice
- Mutual Fund Microservice
- Customer Portal
- Daily Net Worth Microservice

>## 💻&nbsp; System Requirements
-  Git
-  Code Editor (Visual Studio Code, Sublime Text)
