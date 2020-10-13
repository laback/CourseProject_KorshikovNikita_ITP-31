create procedure FillStops
	as
		declare @count int, @nameOfStop varchar(15)
		set @count = 501
		while @count > 0
		begin
			set @nameOfStop = char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
							 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
							 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
							 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
							 +char(rand()*26+65)+char(rand()*26+65)+char(rand()*26+65)
			insert into Stops values(@nameOfStop)
			set @count = @count - 1
		end