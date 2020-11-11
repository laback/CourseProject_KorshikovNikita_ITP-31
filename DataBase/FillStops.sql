create procedure FillStops
	as
		declare @count int, @isStation int, @isHall int, @nameOfStop varchar(15)
		set @count = 501
		while @count > 0
		begin
			set @nameOfStop = char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
							 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
							 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
							 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
							 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
			set @isStation = Rand()*(2 - 0) + 0
			set @isHall = Rand()*(2 - 0) + 0
			insert into Stops values(@nameOfStop, @isStation, @isHall)
			set @count = @count - 1
		end