class MegaGreeter
  attr_accessor :names

  def initialize(names='World')
    @names=names
  end

  def say_hi
    if @names.nil?
      puts '....'
    elsif @names.respond_to?('each')
      @names.each do |name|
        puts "Hello #{name}!"
      end
    else
      puts "Hello #{@names}"
    end

    def say_bye
      if @names.nil?
        puts '...'
      elsif @names.respond_to?('join')
        puts "Goodbye #{@names.join(', ')}"
      else
        puts "Goodbye #{@names}, Come back soon!"
      end
    end
  end

  if __FILE__ == $0
    mg = MegaGreeter.new()
    mg.say_hi
    mg.say_bye

    mg.names = 'Albert'
    mg.say_hi
    mg.say_bye

    mg.names = %w(Albert Brenda Charles)
    mg.say_hi
    mg.say_bye

    mg.names = nil
    mg.say_hi
    mg.say_bye

  end
end