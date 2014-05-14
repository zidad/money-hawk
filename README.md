MoneyHawk
==========
* **etymology**: the moneybird that does see sharp*

C# API for [moneybird](http://www.moneybird.nl)

(The name MoneyHawk originates from the 

This project uses [ServiceStack](https://servicestack.net/) to connect to the moneybird REST API, and I use it to generate exports for my accountants

There's also some [Ruby scripts](/zidad/money-hawk/blob/master/MoneyGem) to export [expenses](/zidad/money-hawk/blob/master/MoneyGem/MoneyHawk/incoming_invoice_download.rb) and [invoices](https://github.com/zidad/money-hawk/blob/master/MoneyGem/MoneyHawk/invoice_download.rb)

This API is far from complete but the samples should make it usable.

The MVC demo project to access the data is running here on Azure:
[http://moneyhawk.azurewebsites.net](http://moneyhawk.azurewebsites.net)

You can register with your moneybird credentials. I'd advise to create separate limited credentials, there's no OAuth or https support yet.

To setup a local database:

- Create a local DB 'MoneyHawk' (the connection string now assumes the default instance [.])
- Execute this in the package manager: 'update-database -Verbose'
