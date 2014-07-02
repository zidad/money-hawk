using System;
using System.Runtime.Serialization;

namespace MoneyHawk.Core
{
    [DataContract]
    public class Contact
    {
        // name	String	No	Read_only, company_name or firstname + lastname
        [DataMember(Name="name")]
        public string Name { get; set; }

        // name	String	No	Read_only, company_name or firstname + lastname
        [DataMember(Name="contact_name")]
        public string ContactName { get; set; }

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
        [DataMember(Name = "chamber_of_commerce")]
        public string ChamberOfCommerce { get; set; }
        
        // city	String	No	
        [DataMember(Name = "city")]
        public string City { get; set; }
        
        // company_name	String	Yes	At least a company_name, firstname or lastname is required
        [DataMember(Name = "company_name")]
        public string CompanyName { get; set; }
        
        // contact_hash	String	No	Read_only, unique hash for the contact
        [DataMember(Name = "contact_hash")]
        public string ContactHash { get; set; }
                
        // country	String	No	
        [DataMember(Name = "country")]
        public string Country { get; set; }
        
        // created_at	Datetime	No	Read_only, for example: 2011_02_15T13:13:50+01:00
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
       
        // customer_id	String	Yes	Unique (customer)id for the contact, for example: C100
        [DataMember(Name = " customer_id")]
        public string CustomerId { get; set; }
        
        // email	String	No	
        [DataMember(Name = "email")]
        public string Email { get; set; }
        
        // firstname	String	Yes	At least a company_name, firstname or lastname is required
        [DataMember(Name = "firstname")]
        public string Firstname { get; set; }
        
        // id	Integer	No	Read_only, the unique id of the contact
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        // lastname	String	Yes	At least a company_name, firstname or lastname is required
        [DataMember(Name = "lastname")]
        public string Lastname { get; set; }
                
        // phone	String	No	
        [DataMember(Name = "phone")]
        public string Phone { get; set; }
        
        // revision	Integer	No	Read_only, incremental integer, increases if contact is updated
        [DataMember(Name = "revision")]
        public int Revision { get; set; }
        
        // send_method	String	No	Allowed values: email, hand or post, default: email
        [DataMember(Name = "send_method")]
        public string SendMethod { get; set; }
        
        // tax_number	String	No	
        [DataMember(Name = "tax_number")]
        public string TaxNumber { get; set; }
        
        // updated_at	Datetime	No	Read_only, for example: 2011_02_15T13:13:50+01:00
        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        // zipcode	String	No	
        [DataMember(Name = "zipcode")]
        public string Zipcode { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {4}, Name: {0} CompanyName: {1}, ContactName: {2}, Country: {3}", Name, CompanyName, ContactName, Country, Id);
        }
    }
}