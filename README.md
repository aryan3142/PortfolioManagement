# 👣 **Portfolio Management**

>## **Project Manager: Aryan Khandelwal**
>## ✍&nbsp; PROJECT OverView

A leading FinTech Services Organization wanted to strengthen its Middleware by 
exposing the core logic related to Investment Portfolio Management as Microservices. This middle ware Microservices have also been hosted on Azure 
so that all the up/downstream applications can get an access to this for performing business transactions.
There is also be a customer Portal developed part of this project that consumes all of these Microservices to view their portfolio information and sell their assets.

### ⚡ Scope & Solution:

As part of the build, the web application has been divided into 5 parts that includes four 'Web Api microservices' and one 'Customer Login Portal'. The individual components
(web apis) provide the required rest-end points and all end-points have been configured and called internally using 'HttpClient' in other microservices and the portal as required. An algorithm has been developed in order to calculate user's investment portfolio's networth.  

The projects ha four web-apis as microservices: 

- Share Price Microservice - s
  This is a Middleware Microservice that performs following operation: 
  - Gets the daily share price of stocks listed in the marketplace.
  
- Mutual Fund Microservice - 
  This is a Middleware Microservice that performs following operation: 
  - Gets NAV value of Mutual Funds listed in the marketplace.

- Calculate Net worth Microservice - 
  This is a Middleware Microservice that performs following operation: 
  - Calculates the current value of share holdings and mutual fund holdings of a user and find out the total current value or net-worth of its investment portfolio based on some developed algorithm.
  - Sell Assets and calculate the final net-worth.

- Customer Portal - 
  A Web Portal that allows a customer to perform the following operations:
  - Login 
  - View the portfolio holdings & networth 
  - Sell assets
  
- Authorization Microservice: - 
  - Service to Service communication using JWT.
  - Pass End User Context across Microservices.
  - Have the token expired after specific amount of time say 15 minutes.
  - Have this service configured in the cloud along with other services.
  
 ### ⚡ Features
 Documentation Requirements:
- All the Microservices are configured with Swagger for documentation.
- Registerd the swagger resources in the Swagger Microservice and enabled them as REST end points.
- Configured this service along with other services in the cloud (Azure).

### ⚡ Individual Components of the System
- [Customer Portal](https://github.com/ryan3142/PortfolioManagement/tree/main/Portfolio%20Management%20-%20Customer%20Portal)
- [Authorization MicroService](https://github.com/ryan3142/PortfolioManagement/tree/main/Authorization)
- [Share Price Microservice](https://github.com/ryan3142/PortfolioManagement/tree/main/Share%20Price%20Microservice)
- [Mutual Fund Microservice](https://github.com/ryan3142/PortfolioManagement/tree/main/Mutual%20Fund%20Microservice)
- [Daily Net Worth Microservice](https://github.com/ryan3142/PortfolioManagement/tree/main/Calculate%20Net%20Worth%20Microservice)

>## 💻&nbsp; System Requirements
-  Git
-  Code Editor (Visual Studio Code, Sublime Text)
