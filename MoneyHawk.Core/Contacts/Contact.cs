using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoneyHawk.Core
{
    /// <summary>
    /// https://developer.moneybird.com/api/contacts/
    /// /contacts	GET	List all contacts
    /// /contacts/synchronization	GET	List all ids and versions
    /// /contacts/synchronization	POST	Fetch contacts with given ids
    /// /contacts/:id	GET	Get contact
    /// /contacts/customer_id/:customer_id	GET	Get contact by customer id
    /// /contacts	POST	Create a new contact
    /// /contacts/:id	PATCH	Update a contact
    /// /contacts/:id	DELETE	Delete a contact
    /// /contacts/:contact_id/notes	POST	Adds note to entity
    /// /contacts/:contact_id/notes/:id	DELETE	Destroys note from entity
    /// </summary>
    public class Contact
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("administration_id")]
        public long AdministrationId { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("delivery_method")]
        public string DeliveryMethod { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("tax_number")]
        public string TaxNumber { get; set; }

        [JsonProperty("chamber_of_commerce")]
        public string ChamberOfCommerce { get; set; }

        [JsonProperty("bank_account")]
        public string BankAccount { get; set; }

        [JsonProperty("attention")]
        public string Attention { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_ubl")]
        public bool EmailUbl { get; set; }

        [JsonProperty("send_invoices_to_attention")]
        public string SendInvoicesToAttention { get; set; }

        [JsonProperty("send_invoices_to_email")]
        public string SendInvoicesToEmail { get; set; }

        [JsonProperty("send_estimates_to_attention")]
        public string SendEstimatesToAttention { get; set; }

        [JsonProperty("send_estimates_to_email")]
        public string SendEstimatesToEmail { get; set; }

        [JsonProperty("sepa_active")]
        public bool SepaActive { get; set; }

        [JsonProperty("sepa_iban")]
        public string SepaIban { get; set; }

        [JsonProperty("sepa_iban_account_name")]
        public string SepaIbanAccountName { get; set; }

        [JsonProperty("sepa_bic")]
        public string SepaBic { get; set; }

        [JsonProperty("sepa_mandate_id")]
        public string SepaMandateId { get; set; }

        [JsonProperty("sepa_mandate_date")]
        public string SepaMandateDate { get; set; }

        [JsonProperty("sepa_sequence_type")]
        public string SepaSequenceType { get; set; }

        [JsonProperty("credit_card_number")]
        public string CreditCardNumber { get; set; }

        [JsonProperty("credit_card_reference")]
        public string CreditCardReference { get; set; }

        [JsonProperty("credit_card_type")]
        public object CreditCardType { get; set; }

        [JsonProperty("tax_number_validated_at")]
        public object TaxNumberValidatedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("sales_invoices_url")]
        public string SalesInvoicesUrl { get; set; }

        [JsonProperty("notes")]
        public IList<JObject> Notes { get; set; }

        [JsonProperty("custom_fields")]
        public IList<JObject> CustomFields { get; set; }

        [JsonProperty("events")]
        public IList<Event> Events { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(CompanyName)}: {CompanyName}, {nameof(Firstname)}: {Firstname}, {nameof(Lastname)}: {Lastname}, {nameof(Email)}: {Email}";
        }
    }
}