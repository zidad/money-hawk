require "rubygems"
require "logger"
require "active_resource"
require "open-uri"
require "date"
require "fileutils"
require 'openssl'

OpenSSL::SSL::VERIFY_PEER = OpenSSL::SSL::VERIFY_NONE

ActiveResource::Base.logger = Logger.new(STDOUT)
ActiveResource::Base.logger.level = Logger::DEBUG
ActiveResource::Base.site = $site = "https://#{ARGV[0]}.moneybird.nl/api/v1.0";
ActiveResource::Base.user = $user = ARGV[1];
ActiveResource::Base.password = $password = ARGV[2];

$month_names = %w(nil, Januari Februari Maart April Mei Juni Juli Augustus September Oktober November December)
$content_types = { 'application/pdf' => 'pdf', 'image/jpeg' => 'jpg', 'message/rfc822' => 'eml' }

class Contact < ActiveResource::Base

end

class IncomingInvoice < ActiveResource::Base

end

def download_incoming_invoice(invoice, attachment, i)
  invoice_date = Date.parse(invoice.invoice_date)

  return if invoice_date.year > 2011
  return if attachment.nil?

  contact = Contact.find(invoice.contact_id)
  directory = "/moneybird/#{invoice_date.year}/inkoopfacturen/#{$month_names[invoice_date.month]}"
  filename = "#{directory}/#{sanitize_filename(contact.company_name)}_#{sanitize_filename(invoice.invoice_id)}_#{i}.#{$content_types[attachment.file_content_type]}"

  FileUtils.mkpath(directory) unless File.exists?(directory)

  return if File.exist? filename

  invoice_url = attachment.original_url

  puts "Downloading invoice #{attachment.original_url} PDF to #{filename}"

  File.open(filename, 'wb') do |fo|
    fo.write open(invoice_url, :http_basic_authentication => [$user, $password]).read
  end
end

def sanitize_filename(filename)
  # Split the name when finding a period which is preceded by some
  # character, and is followed by some character other than a period,
  # if there is no following period that is followed by something
  # other than a period (yeah, confusing, I know)
  fn = filename.split /(?<=.)\.(?=[^.])(?!.*\.[^.])/m

  # We now have one or two parts (depending on whether we could find
  # a suitable period). For each of these parts, replace any unwanted
  # sequence of characters with an underscore
  fn.map! { |s| s.gsub /[^a-z0-9\-]+/i, '_' }

  # Finally, join the parts with a period and return the result
  return fn.join '.'
end

if __FILE__ == $0
    IncomingInvoice.all().find_all { |i| i.state !='unsaved' }.each do
      |invoice| invoice.attachments.each_with_index do
        |attachment, i| download_incoming_invoice invoice, attachment, i
    end
  end
end
