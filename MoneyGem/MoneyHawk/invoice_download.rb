#!/c/tools/ruby193/bin
# /usr/bin/ruby

require "rubygems"
require "logger"
require "active_resource"
require "open-uri"
require "date"
require "fileutils"

ActiveResource::Base.logger = Logger.new(STDOUT)
ActiveResource::Base.logger.level = Logger::DEBUG

OpenSSL::SSL::VERIFY_PEER = OpenSSL::SSL::VERIFY_NONE

class Invoice < ActiveResource::Base
	self.site = "https://#{ARGV[0]}.moneybird.nl/api/v1.0"
	self.user = ARGV[1]
	self.password = ARGV[2]
  #self.headers['authorization'] = 'Bearer mDIDZPSKvXn6g8IryoLnDdMRPrd38Spv3WYuU2Ww' #+ my_oauth2_token

end

def download_invoice(invoice)
	invoice_date = Date.parse(invoice.invoice_date)

	directory = "/c/users/wiebe/moneybird/#{invoice_date.year}/verkoopfacturen/"
	filename = "#{directory}#{invoice.invoice_id}.pdf"

	FileUtils.mkpath(directory) unless File.exists?(directory)

	return if File.exist? filename

	puts "Downloading invoice #{invoice.invoice_id} PDF to #{filename}"

	invoice_url = "https://#{ARGV[0]}.moneybird.nl/invoices/#{invoice.id}.pdf?media=print_on_stationery"

	File.open(filename, 'wb') do |fo|
		fo.write open(invoice_url, :http_basic_authentication => [Invoice.user, Invoice.password]).read
	end
end

Invoice.all().each do |invoice|
	download_invoice invoice
end

