# 👣 **Customer Microservice**

>## **Project Manager: Aryan Khandelwal**
>## ✍&nbsp; Functional Requirements

Customer Portal allows customer to login. Once successfully logged in, the customer can do the following operations:

- Navigate to their profile.

- Navigate to their investment portfolio.

- View the networth of their investment portfolio.

- An option to sell existing assets (assets & mutual funds) has been provided, upon selling any asset the networth of the user's portfolio is updated and displayed.

- For successfully operating the above operations, Customer portal will reach out to the middleware microservices hosted.

 ## ⚡ Flow of the project:
 
 --> User Logins using set of credentials(username & password) through the customer portal. 
 --> 'Authorization microservice' is called by the 'Customer portal' for user authentication.
 --> After successful authentication, a 'JWT token' attached to the response is sent back by the 'Authorization microservice' to the customer portal and the user is authorized their privileges mentioned in their role.
 --> User is than navigated to their profile. 
 --> Upon navigating to user's investment portfolio, NetWorth microservice is called by Customer Portal. 
 --> Networth microservice calls, Share Price & Mutual Fund microservice to get updated price of stocks and MFs in user's investment portfolio. 
 --> 'Net Worth' of User's Investment Portfolio is calculated by 'Net Worth microservice' with the help of an algorithm developed and is sent back as a result to call made by 'Customer Portal' for calculating user's networth and is displayed on user's investment portfolio profile.
 --> Updated Networth is displayed on selling of any stock or MutualFund from user's investment portfolio.

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(793).png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(794).png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(795).png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(796).png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(797).png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(798).png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(799).png>)
