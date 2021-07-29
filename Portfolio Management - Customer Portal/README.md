# 👣 **Customer Microservice**

>## **Project Manager: Aryan Khandelwal**
>## ✍&nbsp; Functional Requirements

Customer Portal allows customer to login. Once successfully logged in, the customer can do the following operations:

- navigate their profile.

- navigate to their investment portfolio.

- view the networth of his or her investment portfolio.

- an option to sell existing assets (assets & mutual funds) has been provided, upon selling any asset the networth of the user's portfolio is updated and displayed.

- for successfully operating the above operations, Customer portal will reach out to the middleware microservices hosted.

 ## ⚡ Flow of the project:
 
 #### Customer Logins using set of credentials through the customer portal --> Authorization microservice is called for authentication --> After authentication customer is authorized using JWT tokens --> Customer is navigated to their profile --> NetWorth microservice is called by Customer Portfolio --> Networth microservice calls, Share Price & Mutual Fund microservice to get updated priced of stocks and MFs in customer portfolio --> Net Worth of User's Investment Portfolio is calculated by Net Worth microservice and displayed --> Updated Networth is displayed on selling of any stock or MutualFund from customer's portfolio.

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(793).png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(794).png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(795).png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(796).png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(797).png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(798).png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Portfolio%20Management%20-%20Customer%20Portal/CustomerPortal/Screenshots/Screenshot%20(799).png>)
