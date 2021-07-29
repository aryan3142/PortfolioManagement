# 👣 **Calculate Net Worth Microservice**

>## **Project Manager: Aryan Khandelwal**
>## ✍&nbsp; Requirements

- Customer Portal App is the only client to this Microservice. An authorized customer view the net worth of his or her investment portfolio.
- Post Authorization, it communicates to the below Microservices for retrieving necessary information.
- Calculate Net worth Microservice will retrieve the stocks and mutual funds corresponds to the customer portfolio. For each stock it will interact with the Daily share price Microservice to get current market price for that stock and calculate the stock value by multiplying no of shares and current market price of the share. It will sum all the stock value.
- The Calculate Networth microservice, for each mutual fund it will interact with Daily Mutual fund NAV Module, to get NAV value of of each mutual fund. It then calculates mutual fund value by multiplying number of units and NAV.
- The networth is calculated as below: Networth = [number of shares of Stock1 * current price of stock1+ number of shares of Stock2 * current price of stock2+… + number of shares of StockN * current price of stockN]+ [number of units of Mutual Fund1 * NAV of Mutual Fund1+ number of units of Mutual Fund2 * NAV of Mutual Fund2+… +number of units of Mutual FundN * NAV of Mutual FundN]
- This Microservice has another feature to sell the assets. The requested assets to sell should be sent thru the Portfolio Details business entity along with the current portfolio detail. Upon selling(out of the current requirement scope), the final networth should be calculated and returned to the web portal 

 ## ⚡ REST End Points: 
 ### Calculate Net worth Microservice 
 o GET: /calculateNetworth (Input: PortfolioDetails | Output: Networth – the computed total amount worth in INR) 
 o POST: /sellAssets (Input: currentDetail : PortfolioDetails, saleDetail : PortfolioDetails | AssetSaleReponse – Sale response status and the balance amount)

## ⚡ Verified both the end-points using postman:

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Calculate%20Net%20Worth%20Microservice/Module_3/Screenshots/calculateNetWorth.png>)

![alt text](<https://github.com/ryan3142/PortfolioManagement/blob/main/Calculate%20Net%20Worth%20Microservice/Module_3/Screenshots/sellAsset.png>)
