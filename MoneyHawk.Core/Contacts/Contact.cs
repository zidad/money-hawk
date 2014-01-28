using System;
using System.Runtime.Serialization;

namespace MoneyHawk.Core
{
    [DataContract]
    public class Contact
    {
        // name	String	No	Read-only, company-name or firstname + lastname
        [DataMember(Name="contact_name")]
        public string Name { get; set; }

          // address1	String	No	
        [DataMember(Name = "address1")]
        public string Address1 { get; set; }
        
          // address2	String	No	
        [DataMember(Name = "address2")]
        public string Address2 { get; set; }
        
          // attention	String	No	
        [DataMember(Name = "attention")]
        public string Attention { get; set; }
        
          // bank-account	String	No	
        [DataMember(Name = "bank_account")]
        public string BankAccount { get; set; }	
        
        // chamber-of-commerce	String	No	
        [DataMember(Name = "chamber-of-commerce")]
        public string ChamberOfCommerce { get; set; }
        
        // city	String	No	
        [DataMember(Name = "city")]
        public string City { get; set; }
        
        // company-name	String	Yes	At least a company-name, firstname or lastname is required
        [DataMember(Name = "company-name")]
        public string CompanyName { get; set; }
        
        // contact-hash	String	No	Read-only, unique hash for the contact
        [DataMember(Name = "contact-hash")]
        public string ContactHash { get; set; }
        
        // contact-name	String	No	Read-only, firstname + lastname
        [DataMember(Name = "contact-name")]
        public string ContactName { get; set; }
        
        // country	String	No	
        [DataMember(Name = "country")]
        public string Country { get; set; }
        
        // created-at	Datetime	No	Read-only, for example: 2011-02-15T13:13:50+01:00
        [DataMember(Name = "created-at")]
        public DateTime CreatedAt { get; set; }
       
        // customer-id	String	Yes	Unique (customer)id for the contact, for example: C100
        [DataMember(Name = " customer-id")]
        public string CustomerId { get; set; }
        
        // email	String	No	
        [DataMember(Name = "email")]
        public string Email { get; set; }
        
        // firstname	String	Yes	At least a company-name, firstname or lastname is required
        [DataMember(Name = "firstname")]
        public string Firstname { get; set; }
        
        // id	Integer	No	Read-only, the unique id of the contact
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        // lastname	String	Yes	At least a company-name, firstname or lastname is required
        [DataMember(Name = "lastname")]
        public string Lastname { get; set; }
                
        // phone	String	No	
        [DataMember(Name = "phone")]
        public string Phone { get; set; }
        
        // revision	Integer	No	Read-only, incremental integer, increases if contact is updated
        [DataMember(Name = "revision")]
        public int Revision { get; set; }
        
        // send-method	String	No	Allowed values: email, hand or post, default: email
        [DataMember(Name = "send-method")]
        public string SendMethod { get; set; }
        
        // tax-number	String	No	
        [DataMember(Name = "tax-number")]
        public string TaxNumber { get; set; }
        
        // updated-at	Datetime	No	Read-only, for example: 2011-02-15T13:13:50+01:00
        [DataMember(Name = "updated-at")]
        public DateTime UpdatedAt { get; set; }
        
        // zipcode	String	No	
        [DataMember(Name = "zipcode")]
        public string Zipcode { get; set; }
      }
}