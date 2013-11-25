namespace MoneyHawk.Core
{
    using System;
    using System.Linq;

    [Serializable]
    public class Contact
    {
        // name	String	No	Read-only, company-name or firstname + lastname
        public string Name { get; set; }

          // address1	String	No	
          public string Address1 { get; set; }
        
          // address2	String	No	
          public string Address2	{ get; set; }
        
          // attention	String	No	
          public string Attention	{ get; set; }
        
          // bank-account	String	No	
          public string BankAccount{ get; set; }	
        
          // chamber-of-commerce	String	No	
          public string ChamberOfCommerce	{ get; set; }
        
          // city	String	No	
          public string City	{ get; set; }
        
          // company-name	String	Yes	At least a company-name, firstname or lastname is required
          public string CompanyName	{ get; set; }
        
          // contact-hash	String	No	Read-only, unique hash for the contact
          public string ContactHash	{ get; set; }
        
          // contact-name	String	No	Read-only, firstname + lastname
          public string ContactName	{ get; set; }
        
          // country	String	No	
          public string Country	{ get; set; }
        
          // created-at	Datetime	No	Read-only, for example: 2011-02-15T13:13:50+01:00
          public DateTime CreatedAt	{ get; set; }
        
          // customer-id	String	Yes	Unique (customer)id for the contact, for example: C100
          public string CustomerId	{ get; set; }
        
          // email	String	No	
          public string Email	{ get; set; }
        
          // firstname	String	Yes	At least a company-name, firstname or lastname is required
          public string Firstname	{ get; set; }
        
          // id	Integer	No	Read-only, the unique id of the contact
          public int Id	{ get; set; }
        
          // lastname	String	Yes	At least a company-name, firstname or lastname is required
          public string Lastname	{ get; set; }
                
          // phone	String	No	
          public string Phone	{ get; set; }
        
          // revision	Integer	No	Read-only, incremental integer, increases if contact is updated
          public int Revision	{ get; set; }
        
          // send-method	String	No	Allowed values: email, hand or post, default: email
          public string SendMethod	{ get; set; }
        
          // tax-number	String	No	
          public string TaxNumber	{ get; set; }
        
          // updated-at	Datetime	No	Read-only, for example: 2011-02-15T13:13:50+01:00
          public DateTime UpdatedAt	{ get; set; }
        
          // zipcode	String	No	
          public string Zipcode	{ get; set; }
      }
}